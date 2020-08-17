// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class PairFilter<T> : IDisceteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_elementsBetweenPair;

		public PairFilter(byte elementsBetweenPair)
		{
			m_elementsBetweenPair = elementsBetweenPair;
		}

		public PairFilter([NotNull] PairFilter<T> other)
		{
			m_elementsBetweenPair = other.m_elementsBetweenPair;
		}

		public byte elementsBetweenPair
		{
			[Pure]
			get => m_elementsBetweenPair;
			set => m_elementsBetweenPair = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => (byte)(m_elementsBetweenPair + 1);
		}

		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return s_comparer.Equals(sequence[sequenceLength - m_elementsBetweenPair - 1], newValue);
		}
	}
}
