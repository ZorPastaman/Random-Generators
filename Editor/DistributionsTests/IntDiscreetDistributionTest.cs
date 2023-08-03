// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;
using Zor.RandomGenerators.DiscreteDistributions;

namespace Zor.RandomGenerators.DistributionsTests
{
	/// <summary>
	/// Editor window for testing <see cref="IDiscreteGenerator{T}"/> of type <see langword="int"/>.
	/// </summary>
	public sealed class IntDiscreteDistributionTest : EditorWindow
	{
		private ObjectField m_intProviderView;
		private IntegerField m_generationsPerFrameView;
		private CurveField m_curveView;

		private uint m_generationsPerFrame;

		private readonly AnimationCurve m_curve = new();
		private IDiscreteGenerator<int> m_generator;

		private readonly List<(int, uint)> m_generatedCounts = new();
		private uint m_generations;

		private Keyframe[] m_keyframes;

		[MenuItem("Window/Random Generators/Integer Discrete Distribution Test", priority = 2021)]
		public static void OpenWindow()
		{
			GetWindow<IntDiscreteDistributionTest>("Integer Discrete Distribution Test");
		}

		private void CreateGUI()
		{
			VisualElement root = rootVisualElement;

			m_intProviderView = new ObjectField("Int Discrete Generator Provider") {objectType = typeof(DiscreteGeneratorProvider<int>)};
			root.Add(m_intProviderView);

			m_generationsPerFrameView = new IntegerField("Generators Per Frame") {value = 100};
			root.Add(m_generationsPerFrameView);

			var startButton = new Button(StartProcess) { text = "Start" };
			root.Add(startButton);

			var stopButton = new Button(StopProcess) { text = "Stop" };
			root.Add(stopButton);

			m_curveView = new CurveField("Curve") { value = m_curve, style = { height = 500f } };
			root.Add(m_curveView);
		}

		private void StartProcess()
		{
			var generatorProvider = m_intProviderView.value as DiscreteGeneratorProvider<int>;

			if (generatorProvider == null)
			{
				return;
			}

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

		private void StopProcess()
		{
			m_generator = null;
		}

		private void Update()
		{
			if (m_generator == null)
			{
				return;
			}

			for (uint generation = 0u; generation < m_generationsPerFrame; ++generation)
			{
				Profiler.BeginSample("IntDiscreteTest.Generate");

				int generatedValue = m_generator.Generate();

				Profiler.EndSample();

				int index = FindGeneratedIndex(generatedValue);

				if (index >= 0)
				{
					(int valueIndex, uint generatedCount) = m_generatedCounts[index];
					m_generatedCounts[index] = (valueIndex, generatedCount + 1);
				}
				else
				{
					m_generatedCounts.Add((generatedValue, 1));
					m_generatedCounts.Sort((lhs, rhs) => lhs.Item1.CompareTo(rhs.Item1));
				}

				++m_generations;
			}

			int count = m_generatedCounts.Count;

			Array.Resize(ref m_keyframes, count);

			for (int i = 0; i < count; ++i)
			{
				(int value, uint generatedCount) = m_generatedCounts[i];
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

			m_curve.keys = m_keyframes;
			m_curveView.value = m_curve;
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
