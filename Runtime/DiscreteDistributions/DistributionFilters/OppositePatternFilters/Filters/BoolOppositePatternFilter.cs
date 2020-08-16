// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class BoolOppositePatternFilter : IDisceteFilter<bool>
	{
		private byte m_maxPatternLength;

		public BoolOppositePatternFilter(byte maxPatternLength)
		{
			m_maxPatternLength = maxPatternLength;
		}

		public BoolOppositePatternFilter([NotNull] BoolOppositePatternFilter other)
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
		public bool NeedRegenerate(bool[] sequence, bool newValue, byte sequenceLength)
		{
			byte patternLength = (byte)(m_maxPatternLength * 2 + 1);

			if (sequenceLength < patternLength ||
				sequence[sequenceLength - m_maxPatternLength - 1] == newValue)
			{
				return false;
			}

			bool nonOppositePattern = false;

			for (int i = sequenceLength - patternLength, j = sequenceLength - m_maxPatternLength;
				!nonOppositePattern && j < sequenceLength;
				++i, ++j)
			{
				nonOppositePattern = sequence[i] == sequence[j];
			}

			return !nonOppositePattern;
		}
	}
}
