// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class SameSequenceFilter<T> : IDisceteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_maxSameSequenceLength;

		public SameSequenceFilter(byte maxSameSequenceLength)
		{
			m_maxSameSequenceLength = maxSameSequenceLength;
		}

		public SameSequenceFilter([NotNull] SameSequenceFilter<T> other)
		{
			m_maxSameSequenceLength = other.m_maxSameSequenceLength;
		}

		public byte maxSameSequenceLength
		{
			[Pure]
			get => m_maxSameSequenceLength;
			set => m_maxSameSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_maxSameSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			bool hasDifferent = false;

			for (int i = sequenceLength - m_maxSameSequenceLength; !hasDifferent && i < sequenceLength; ++i)
			{
				hasDifferent = !s_comparer.Equals(sequence[i], newValue);
			}

			return !hasDifferent;
		}
	}
}
