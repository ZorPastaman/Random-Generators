// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DistributionsTests
{
	public sealed class ContinuousDistributionTest : EditorWindow
	{
		private ObjectField m_continuousProviderView;
		private FloatField m_stepLengthView;
		private IntegerField m_generationsPerFrameView;
		private CurveField m_curveView;

		private float m_stepLength;
		private uint m_generationsPerFrame;

		private readonly AnimationCurve m_curve = new();
		private IContinuousGenerator m_generator;

		private readonly List<(int, uint)> m_generatedCounts = new();
		private uint m_generations;

		private Keyframe[] m_keyframes;

		[MenuItem("Window/Random Generators/Continuous Distribution Test", priority = 2021)]
		public static void OpenWindow()
		{
			GetWindow<ContinuousDistributionTest>("Continuous Distribution Test");
		}

		private void CreateGUI()
		{
			VisualElement root = rootVisualElement;

			m_continuousProviderView = new ObjectField("Continuous Generator Provider") {objectType = typeof(ContinuousGeneratorProvider)};
			root.Add(m_continuousProviderView);

			m_stepLengthView = new FloatField("Step Length") {value = 0.1f};
			root.Add(m_stepLengthView);

			m_generationsPerFrameView = new IntegerField("Generators Per Frame") {value = 100};
			root.Add(m_generationsPerFrameView);

			var startButton = new Button(StartProcess) { text = "Start" };
			root.Add(startButton);

			m_curveView = new CurveField("Curve") { value = m_curve, style = { height = 500f } };
			root.Add(m_curveView);
		}

		private void StartProcess()
		{
			var generatorProvider = m_continuousProviderView.value as ContinuousGeneratorProvider;

			if (generatorProvider == null)
			{
				return;
			}

			m_stepLength = m_stepLengthView.value;
			m_generator = generatorProvider.generator;
			m_generationsPerFrame = (uint)m_generationsPerFrameView.value;

			if (m_generationsPerFrame == 0u)
			{
				m_generationsPerFrame = 1u;
			}

			m_generatedCounts.Clear();
			m_generations = 0;
			m_keyframes = null;
		}

		private void Update()
		{
			if (m_generator == null)
			{
				return;
			}

			for (uint generation = 0u; generation < m_generationsPerFrame; ++generation)
			{
				Profiler.BeginSample("ContinuousTest.Generate");

				float generatedValue = m_generator.Generate();

				Profiler.EndSample();

				int pointIndex = FindClosestPointIndex(generatedValue);
				int index = FindGeneratedIndex(pointIndex);

				if (index >= 0)
				{
					(int valueIndex, uint generatedCount) = m_generatedCounts[index];
					m_generatedCounts[index] = (valueIndex, generatedCount + 1);
				}
				else
				{
					m_generatedCounts.Add((pointIndex, 1));
					m_generatedCounts.Sort((lhs, rhs) => lhs.Item1.CompareTo(rhs.Item1));
				}

				++m_generations;

				int count = m_generatedCounts.Count;

				Array.Resize(ref m_keyframes, count);

				for (int i = 0; i < count; ++i)
				{
					(int value, uint generatedCount) = m_generatedCounts[i];
					m_keyframes[i] = new Keyframe(value * m_stepLength, (float)generatedCount / m_generations);

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

			m_curve.keys = m_keyframes;
			m_curveView.value = m_curve;
		}

		private int FindClosestPointIndex(float value)
		{
			int floorIndex = Mathf.FloorToInt(value / m_stepLength);
			int ceilingIndex = floorIndex + 1;

			float floor = floorIndex * m_stepLength;
			float ceiling = ceilingIndex * m_stepLength;

			return Mathf.Abs(value - floor) > Mathf.Abs(ceiling - value) ? ceilingIndex : floorIndex;
		}

		private int FindGeneratedIndex(int valueIndex)
		{
			for (int i = 0, count = m_generatedCounts.Count; i < count; ++i)
			{
				if (valueIndex == m_generatedCounts[i].Item1)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
