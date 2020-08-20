// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class FrequentValueFilter<T> : IDisceteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_controlledSequenceLength;
		private byte m_allowedRepeats;

		public FrequentValueFilter(byte controlledSequenceLength, byte allowedRepeats)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_allowedRepeats = allowedRepeats;
		}

		public FrequentValueFilter([NotNull] FrequentValueFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_allowedRepeats = other.m_allowedRepeats;
		}

		public byte controlledSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
			set => m_controlledSequenceLength = value;
		}

		public byte allowedRepeats
		{
			[Pure]
			get => m_allowedRepeats;
			set => m_allowedRepeats = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
		}

		[Pure]
		public unsafe bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			byte repeats = 0;

			for (byte i = 0; i < sequenceLength; ++i)
			{
				bool equal = s_comparer.Equals(sequence[i], newValue);
				repeats += *(byte*)&equal;
			}

			return repeats > m_allowedRepeats - 1;
		}
	}
}
