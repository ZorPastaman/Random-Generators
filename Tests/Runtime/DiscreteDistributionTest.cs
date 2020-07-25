// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Debug = UnityEngine.Debug;

namespace Zor.RandomGenerators.Tests
{
	public sealed class DiscreteDistributionTest : MonoBehaviour
	{
#pragma warning disable CS0649
		[SerializeField, RequireDiscreteRandomGenerator(typeof(int))]
		private DiscreteRandomGeneratorProviderReference m_GeneratorProviderReference;
		[SerializeField] private uint m_GenerationsPerFrame = 100;
		[SerializeField] private List<ResultEntry> m_Results = new List<ResultEntry>();
		[SerializeField] private uint m_PerformanceTestsCount = 10000;
#pragma warning restore CS0649

		private IDiscreteRandomGenerator<int> m_randomGenerator;

		private void Start()
		{
			m_randomGenerator = m_GeneratorProviderReference.GetRandomGenerator<int>();

			var stopWatch = Stopwatch.StartNew();
			for (uint i = 0; i < m_PerformanceTestsCount; ++i)
			{
				m_randomGenerator.Generate();
			}
			stopWatch.Stop();
			Debug.Log($"[DiscreteDistributionTest] Performance test. Ticks: {stopWatch.ElapsedTicks}, Milliseconds: {stopWatch.ElapsedMilliseconds}");
		}

		private void Update()
		{
			for (int i = 0; i < m_GenerationsPerFrame; ++i)
			{
				int generated = m_randomGenerator.Generate();
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
						Count = 1
					});
				}
			}

			m_Results.Sort((lhs, rhs) => lhs.Element.CompareTo(rhs.Element));

			uint sum = 0;
			for (int i = 0, count = m_Results.Count; i < count; ++i)
			{
				sum += m_Results[i].Count;
			}

			for (int i = 0, count = m_Results.Count; i < count; ++i)
			{
				ResultEntry entry = m_Results[i];
				entry.Possibility = (float)entry.Count / sum;
				m_Results[i] = entry;
			}
		}

		private int FindGeneratedIndex(int generated)
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
			public int Element;
			public uint Count;
			public float Possibility;
		}
	}
}
