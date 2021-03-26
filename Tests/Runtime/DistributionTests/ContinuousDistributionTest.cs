// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;
using Zor.RandomGenerators.ContinuousDistributions;
using Debug = UnityEngine.Debug;

namespace Zor.RandomGenerators.Tests.DistributionTests
{
	public sealed class ContinuousDistributionTest : MonoBehaviour
	{
#pragma warning disable CS0649
		[SerializeField] private AnimationCurve m_Curve;
		[SerializeField] private float m_StepLength = 0.1f;
		[SerializeField] private ContinuousGeneratorProviderReference m_GeneratorProviderReference;
		[SerializeField] private uint m_GenerationsPerFrame = 100u;
		[SerializeField] private uint m_PerformanceTestsCount = 10000u;
#pragma warning restore CS0649

		private IContinuousGenerator m_generator;

		private readonly List<(float, uint)> m_generatedCounts = new List<(float, uint)>();
		private uint m_generations;

		private Keyframe[] m_keyframes;

		private void Start()
		{
			m_generator = m_GeneratorProviderReference.generator;

			if (m_generator == null)
			{
				enabled = false;
				return;
			}

			var stopWatch = Stopwatch.StartNew();
			for (uint i = 0u; i < m_PerformanceTestsCount; ++i)
			{
				m_generator.Generate();
			}
			stopWatch.Stop();
			Debug.Log($"[ContinuousDistributionTest] Performance test. Ticks: {stopWatch.ElapsedTicks}, Milliseconds: {stopWatch.ElapsedMilliseconds}");
		}

		private void Update()
		{
			for (uint generation = 0u; generation < m_GenerationsPerFrame; ++generation)
			{
				Profiler.BeginSample("ContinuousTest.Generate");

				float generatedValue = m_generator.Generate();

				Profiler.EndSample();

				int index = FindGeneratedIndex(generatedValue);

				if (index >= 0)
				{
					(float value, uint generatedCount) = m_generatedCounts[index];
					m_generatedCounts[index] = (value, generatedCount + 1);
				}
				else
				{
					float sign = Mathf.Sign(generatedValue);
					generatedValue *= sign;
					float lessValue = (int)(generatedValue / m_StepLength) * m_StepLength + m_StepLength / 2f;
					float greaterValue = lessValue + m_StepLength;

					float point = (generatedValue - lessValue) / (greaterValue - lessValue) < 0.5f
						? lessValue
						: greaterValue;
					point *= sign;

					m_generatedCounts.Add((point, 1));
					m_generatedCounts.Sort((lhs, rhs) => lhs.Item1.CompareTo(rhs.Item1));
				}

				++m_generations;

				int count = m_generatedCounts.Count;

				Array.Resize(ref m_keyframes, count);

				for (int i = 0; i < count; ++i)
				{
					(float value, uint generatedCount) = m_generatedCounts[i];
					m_keyframes[i] = new Keyframe(value, (float)generatedCount / m_generations);

					if (i > 0)
					{
						m_keyframes[i].inTangent = (m_keyframes[i].value - m_keyframes[i - 1].value) /
							(m_keyframes[i].time - m_keyframes[i - 1].time);
					}

					if (i < count - 1)
					{
						m_keyframes[i].outTangent = (m_keyframes[i + 1].value - m_keyframes[i].value) /
							(m_keyframes[i + 1].time - m_keyframes[i].time);
					}
				}
			}

			m_Curve.keys = m_keyframes;
		}

		private int FindGeneratedIndex(float value)
		{
			for (int i = 0, count = m_generatedCounts.Count; i < count; ++i)
			{
				if (Mathf.Abs(m_generatedCounts[i].Item1 - value) <= m_StepLength / 2f + m_StepLength / 10f)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
