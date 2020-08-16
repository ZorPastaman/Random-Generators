// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class SamePatternFilter<T> : IDisceteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_maxPatternLength;

		public SamePatternFilter(byte maxPatternLength)
		{
			m_maxPatternLength = maxPatternLength;
		}

		public SamePatternFilter([NotNull] SamePatternFilter<T> other)
		{
			m_maxPatternLength = other.m_maxPatternLength;
		}

		public byte maxPatternLength
		{
			[Pure]
			get => m_maxPatternLength;
			set => m_maxPatternLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => (byte)(m_maxPatternLength * 2 + 1);
		}

		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			byte patternLength = (byte)(m_maxPatternLength * 2 + 1);

			if (sequenceLength < patternLength ||
				!s_comparer.Equals(sequence[sequenceLength - m_maxPatternLength - 1], newValue))
			{
				return false;
			}

			bool nonPattern = false;

			for (int i = sequenceLength - patternLength, j = sequenceLength - m_maxPatternLength;
				!nonPattern && j < sequenceLength;
				++i, ++j)
			{
				nonPattern = !s_comparer.Equals(sequence[i], sequence[j]);
			}

			return !nonPattern;
		}
	}
}
