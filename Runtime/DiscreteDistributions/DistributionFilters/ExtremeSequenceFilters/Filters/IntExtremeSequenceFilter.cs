// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[Serializable]
	public sealed class IntExtremeSequenceFilter : IDiscreteFilter<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_ExpectedMin;
		[SerializeField] private int m_ExpectedMax = 10;
		[SerializeField] private uint m_Range = 5;
		[SerializeField] private byte m_ExtremeSequenceLength = 6;
#pragma warning restore CS0649

		public IntExtremeSequenceFilter()
		{
		}

		public IntExtremeSequenceFilter(int expectedMin, int expectedMax, uint range, byte extremeSequenceLength)
		{
			m_ExpectedMin = expectedMin;
			m_ExpectedMax = expectedMax;
			m_Range = range;
			m_ExtremeSequenceLength = extremeSequenceLength;
		}

		public IntExtremeSequenceFilter([NotNull] IntExtremeSequenceFilter other)
		{
			m_ExpectedMin = other.m_ExpectedMin;
			m_ExpectedMax = other.m_ExpectedMax;
			m_Range = other.m_Range;
			m_ExtremeSequenceLength = other.m_ExtremeSequenceLength;
		}

		public int expectedMin
		{
			[Pure]
			get => m_ExpectedMin;
			set => m_ExpectedMin = value;
		}

		public int expectedMax
		{
			[Pure]
			get => m_ExpectedMax;
			set => m_ExpectedMax = value;
		}

		public uint range
		{
			[Pure]
			get => m_Range;
			set => m_Range = value;
		}

		public byte extremeSequenceLength
		{
			[Pure]
			get => m_ExtremeSequenceLength;
			set => m_ExtremeSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_ExtremeSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(int[] sequence, int newValue, byte sequenceLength)
		{
			int extreme;

			if (newValue < m_ExpectedMin + m_Range)
			{
				extreme = m_ExpectedMin;
			}
			else if (newValue > m_ExpectedMax - m_Range)
			{
				extreme = m_ExpectedMax;
			}
			else
			{
				return false;
			}

			bool inRange = true;

			for (int i = sequenceLength - m_ExtremeSequenceLength; inRange && i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - extreme) <= m_Range;
			}

			return inRange;
		}
	}
}
