// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[Serializable]
	public sealed class BoolOppositePatternFilter : IDiscreteFilter<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_MaxPatternLength;
#pragma warning restore CS0649

		public BoolOppositePatternFilter()
		{
		}

		public BoolOppositePatternFilter(byte maxPatternLength)
		{
			m_MaxPatternLength = maxPatternLength;
		}

		public BoolOppositePatternFilter([NotNull] BoolOppositePatternFilter other)
		{
			m_MaxPatternLength = other.m_MaxPatternLength;
		}

		public byte maxPatternLength
		{
			[Pure]
			get => m_MaxPatternLength;
			set => m_MaxPatternLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => (byte)(m_MaxPatternLength * 2 + 1);
		}

		[Pure]
		public bool NeedRegenerate(bool[] sequence, bool newValue, byte sequenceLength)
		{
			if (sequence[sequenceLength - m_MaxPatternLength - 1] == newValue)
			{
				return false;
			}

			bool nonOppositePattern = false;

			for (int i = sequenceLength - m_MaxPatternLength * 2 - 1, j = sequenceLength - m_MaxPatternLength;
				!nonOppositePattern && j < sequenceLength;
				++i, ++j)
			{
				nonOppositePattern = sequence[i] == sequence[j];
			}

			return !nonOppositePattern;
		}
	}
}
