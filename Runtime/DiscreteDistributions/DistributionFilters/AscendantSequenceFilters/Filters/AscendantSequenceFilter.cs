// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class AscendantSequenceFilter<T> : IDiscreteFilter<T> where T : IComparable<T>
	{
		private byte m_ascendantSequenceLength;

		public AscendantSequenceFilter(byte ascendantSequenceLength)
		{
			m_ascendantSequenceLength = ascendantSequenceLength;
		}

		public AscendantSequenceFilter([NotNull] AscendantSequenceFilter<T> other)
		{
			m_ascendantSequenceLength = other.m_ascendantSequenceLength;
		}

		public byte ascendantSequenceLength
		{
			[Pure]
			get => m_ascendantSequenceLength;
			set => m_ascendantSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_ascendantSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			bool notAscending = false;

			for (int i = sequenceLength - m_ascendantSequenceLength + 1; !notAscending && i < sequenceLength; ++i)
			{
				notAscending = sequence[i - 1].CompareTo(sequence[i]) >= 0;
			}

			return !notAscending && sequence[sequenceLength - 1].CompareTo(newValue) < 0;
		}
	}
}
