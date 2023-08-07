// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;
using Zor.RandomGenerators.DiscreteDistributions;

namespace Zor.RandomGenerators.DistributionsTests
{
	/// <summary>
	/// Editor window for testing <see cref="IDiscreteGenerator{T}"/> of type <see langword="bool"/>.
	/// </summary>
	public sealed class BoolDiscreteDistributionTest : EditorWindow
	{
		private ObjectField m_boolProviderView;
		private IntegerField m_generationsPerFrameView;
		private IntegerField m_truesView;
		private IntegerField m_falsesView;
		private CurveField m_curveView;

		private uint m_generationsPerFrame;

		private readonly AnimationCurve m_curve = new();
		private IDiscreteGenerator<bool> m_generator;

		private uint m_trues;
		private uint m_falses;
		private uint m_generations;

		private Keyframe[] m_keyframes;

		[MenuItem("Window/Random Generators/Boolean Discrete Distribution Test", priority = 2021)]
		public static void OpenWindow()
		{
			var window = GetWindow<BoolDiscreteDistributionTest>("Boolean Discrete Distribution Test");
			window.minSize = new Vector2(1000f, 620f);
		}

		private void CreateGUI()
		{
			VisualElement root = rootVisualElement;

			m_boolProviderView = new ObjectField("Bool Discrete Generator Provider") {objectType = typeof(DiscreteGeneratorProvider<bool>)};
			root.Add(m_boolProviderView);

			m_generationsPerFrameView = new IntegerField("Generators Per Frame") {value = 100};
			root.Add(m_generationsPerFrameView);

			var startButton = new Button(StartProcess) { text = "Start" };
			root.Add(startButton);

			var stopButton = new Button(StopProcess) { text = "Stop" };
			root.Add(stopButton);

			m_truesView = new IntegerField("Trues");
			root.Add(m_truesView);

			m_falsesView = new IntegerField("Falses");
			root.Add(m_falsesView);

			m_curveView = new CurveField("Curve") { value = m_curve, style = { height = 500f } };
			root.Add(m_curveView);
		}

		private void StartProcess()
		{
			var generatorProvider = m_boolProviderView.value as DiscreteGeneratorProvider<bool>;

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

			m_trues = 0u;
			m_falses = 0u;
			m_generations = 0;
			m_keyframes = new Keyframe[2];
			m_keyframes[0] = new Keyframe(0f, 0f);
			m_keyframes[1] = new Keyframe(1f, 0f);
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

				bool generatedValue = m_generator.Generate();

				Profiler.EndSample();

				if (generatedValue)
				{
					++m_trues;
				}
				else
				{
					++m_falses;
				}

				++m_generations;
			}

			m_keyframes[0].value = (float)m_falses / m_generations;
			m_keyframes[1].value = (float)m_trues / m_generations;

			m_truesView.value = (int)m_trues;
			m_falsesView.value = (int)m_falses;
			m_curve.keys = m_keyframes;
			m_curveView.value = m_curve;
		}
	}
}
