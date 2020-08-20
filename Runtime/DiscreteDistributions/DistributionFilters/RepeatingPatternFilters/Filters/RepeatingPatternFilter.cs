// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class RepeatingPatternFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		[NotNull] private T[] m_patternCache;
		private byte m_controlledSequenceLength;
		private byte m_patternLength;

		public RepeatingPatternFilter(byte controlledSequenceLength, byte patternLength)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_patternLength = patternLength;
			m_patternCache = new T[m_patternLength];
		}

		public RepeatingPatternFilter([NotNull] RepeatingPatternFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_patternLength = other.m_patternLength;
			m_patternCache = new T[m_patternLength];
		}

		public byte controlledSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
			set => m_controlledSequenceLength = value;
		}

		public byte patternLength
		{
			[Pure]
			get => m_patternLength;
			set
			{
				if (m_patternLength == value)
				{
					return;
				}

				m_patternLength = value;
				m_patternCache = new T[m_patternLength];
			}
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			for (int i = sequenceLength - m_patternLength + 1, j = 0; i < sequenceLength; ++i, ++j)
			{
				m_patternCache[j] = sequence[i];
			}
			m_patternCache[m_patternLength - 1] = newValue;

			bool foundPattern = false;

			for (int i = sequenceLength - m_controlledSequenceLength + 1;
				!foundPattern && i < sequenceLength - m_patternLength;
				++i)
			{
				foundPattern = CheckSequenceAt(sequence, i);
			}

			Array.Clear(m_patternCache, 0, m_patternLength);

			return foundPattern;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private bool CheckSequenceAt([NotNull] T[] sequence, int index)
		{
			bool foundPattern = true;

			for (int i = index, j = 0; foundPattern && i < index + m_patternLength; ++i, ++j)
			{
				foundPattern = s_comparer.Equals(sequence[i], m_patternCache[j]);
			}

			return foundPattern;
		}
	}
}
