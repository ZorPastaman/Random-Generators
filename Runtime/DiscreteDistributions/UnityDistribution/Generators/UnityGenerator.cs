// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	[Serializable]
	public sealed class UnityGenerator : IDiscreteGenerator<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Min;
		[SerializeField] private int m_Max = 1;
#pragma warning restore CS0649

		public UnityGenerator()
		{
		}

		public UnityGenerator(int min, int max)
		{
			m_Min = min;
			m_Max = max;
		}

		public UnityGenerator([NotNull] UnityGenerator other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
		}

		public int min
		{
			[Pure]
			get => m_Min;
			set => m_Min = value;
		}

		public int max
		{
			[Pure]
			get => m_Max;
			set => m_Max = value;
		}

		[Pure]
		public int Generate()
		{
			return Random.Range(m_Min, m_Max);
		}
	}
}
