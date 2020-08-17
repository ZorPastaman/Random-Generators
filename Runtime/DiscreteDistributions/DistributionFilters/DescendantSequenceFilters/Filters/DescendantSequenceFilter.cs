// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class DescendantSequenceFilter<T> : IDisceteFilter<T> where T : IComparable<T>
	{
		private byte m_descendantSequenceLength;

		public DescendantSequenceFilter(byte descendantSequenceLength)
		{
			m_descendantSequenceLength = descendantSequenceLength;
		}

		public DescendantSequenceFilter([NotNull] DescendantSequenceFilter<T> other)
		{
			m_descendantSequenceLength = other.m_descendantSequenceLength;
		}

		public byte descendantSequenceLength
		{
			[Pure]
			get => m_descendantSequenceLength;
			set => m_descendantSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_descendantSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			bool notDescending = false;

			for (int i = sequenceLength - m_descendantSequenceLength + 1; !notDescending && i < sequenceLength; ++i)
			{
				notDescending = sequence[i - 1].CompareTo(sequence[i]) <= 0;
			}

			return !notDescending && sequence[sequenceLength - 1].CompareTo(newValue) > 0;
		}
	}
}
