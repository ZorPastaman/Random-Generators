// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Diagnostics;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Debug = UnityEngine.Debug;

namespace Zor.RandomGenerators.Tests
{
	public sealed class BoolDiscreteDistributionTest : MonoBehaviour
	{
#pragma warning disable CS0649
		[SerializeField, RequireDiscreteGenerator(typeof(bool))]
		private DiscreteGeneratorProviderReference m_GeneratorProviderReference;
		[SerializeField] private uint m_GenerationsPerFrame = 100;
		[SerializeField] private uint m_TrueCount;
		[SerializeField] private uint m_FalseCount;
		[SerializeField] private uint m_PerformanceTestsCount = 10000;
#pragma warning restore CS0649

		private IDiscreteGenerator<bool> m_generator;

		private void Start()
		{
			m_generator = m_GeneratorProviderReference.GetGenerator<bool>();

			if (m_generator == null)
			{
				enabled = false;
				return;
			}

			var stopWatch = Stopwatch.StartNew();
			for (uint i = 0; i < m_PerformanceTestsCount; ++i)
			{
				m_generator.Generate();
			}
			stopWatch.Stop();
			Debug.Log($"[BoolDiscreteDistributionTest] Performance test. Ticks: {stopWatch.ElapsedTicks}, Milliseconds: {stopWatch.ElapsedMilliseconds}");
		}

		private void Update()
		{
			for (int i = 0; i < m_GenerationsPerFrame; ++i)
			{
				if (m_generator.Generate())
				{
					++m_TrueCount;
				}
				else
				{
					++m_FalseCount;
				}
			}
		}
	}
}
