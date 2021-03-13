// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;
using Zor.RandomGenerators.DiscreteDistributions;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Debug = UnityEngine.Debug;

namespace Zor.RandomGenerators.Tests.DistributionTests
{
	public sealed class FloatDiscreteDistributionTest : MonoBehaviour
	{
#pragma warning disable CS0649
		[SerializeField, RequireDiscreteGenerator(typeof(float))]
		private DiscreteGeneratorProviderReference m_GeneratorProviderReference;
		[SerializeField] private uint m_GenerationsPerFrame = 100u;
		[SerializeField] private List<ResultEntry> m_Results = new List<ResultEntry>();
		[SerializeField] private AnimationCurve m_ResultsCurve;
		[SerializeField] private uint m_PerformanceTestsCount = 10000u;
#pragma warning restore CS0649

		private IDiscreteGenerator<float> m_generator;

		private Keyframe[] m_keyframes;

		private void Start()
		{
			m_generator = m_GeneratorProviderReference.GetGenerator<float>();

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
			Debug.Log($"[FloatDiscreteDistributionTest] Performance test. Ticks: {stopWatch.ElapsedTicks}, Milliseconds: {stopWatch.ElapsedMilliseconds}");
		}

		private void Update()
		{
			for (int i = 0; i < m_GenerationsPerFrame; ++i)
			{
				Profiler.BeginSample("FloatDiscreteTest.Generate");

				float generated = m_generator.Generate();

				Profiler.EndSample();

				int index = FindGeneratedIndex(generated);

				if (index >= 0)
				{
					ResultEntry resultEntry = m_Results[index];
					++resultEntry.Count;
					m_Results[index] = resultEntry;
				}
				else
				{
					m_Results.Add(new ResultEntry
					{
						Element = generated,
						Count = 1u
					});
				}
			}

			m_Results.Sort((lhs, rhs) => lhs.Element.CompareTo(rhs.Element));

			uint sum = 0u;
			for (int i = 0, count = m_Results.Count; i < count; ++i)
			{
				sum += m_Results[i].Count;
			}

			for (int i = 0, count = m_Results.Count; i < count; ++i)
			{
				ResultEntry entry = m_Results[i];
				entry.Possibility = entry.Count / sum;
				m_Results[i] = entry;
			}

			int resultsCount = m_Results.Count;

			Array.Resize(ref m_keyframes, resultsCount);

			for (int i = 0; i < resultsCount; ++i)
			{
				ResultEntry result = m_Results[i];
				m_keyframes[i] = new Keyframe(result.Element, result.Possibility);

				if (i > 0)
				{
					m_keyframes[i].inTangent = (m_keyframes[i].value - m_keyframes[i - 1].value) /
						(m_keyframes[i].time - m_keyframes[i - 1].time);
				}

				if (i < resultsCount - 1)
				{
					m_keyframes[i].outTangent = (m_keyframes[i + 1].value - m_keyframes[i].value) /
						(m_keyframes[i + 1].time - m_keyframes[i].time);
				}
			}

			m_ResultsCurve.keys = m_keyframes;
		}

		private int FindGeneratedIndex(float generated)
		{
			for (int i = 0, count = m_Results.Count; i < count; ++i)
			{
				if (m_Results[i].Element == generated)
				{
					return i;
				}
			}

			return -1;
		}

		[Serializable]
		private struct ResultEntry
		{
			public float Element;
			public uint Count;
			public float Possibility;
		}
	}
}
