// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms a pattern the same to a pattern
	/// some elements before.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class RepeatingPatternFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_controlledSequenceLength;
		private byte m_patternLength;

		/// <summary>
		/// Creates a <see cref="RepeatingPatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="patternLength"></param>
		public RepeatingPatternFilter(byte controlledSequenceLength, byte patternLength)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_patternLength = patternLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RepeatingPatternFilter([NotNull] RepeatingPatternFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_patternLength = other.m_patternLength;
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
			set => m_patternLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_controlledSequenceLength, m_patternLength);
		}

		/// <summary>
		/// Checks if the new value <paramref name="newValue"/> forms a pattern the same to a pattern
		/// some elements before and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="patternLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte controlledSequenceLength, byte patternLength)
		{
			int checkStartIndex = sequenceLength - patternLength + 1;
			int samePatternIndex = sequenceLength - controlledSequenceLength;
			bool foundPattern = false;

			for (int stopIndex = checkStartIndex - patternLength + 1;
				!foundPattern & samePatternIndex < stopIndex;
				++samePatternIndex)
			{
				foundPattern = s_comparer.Equals(sequence[samePatternIndex + patternLength - 1], newValue) &&
					IsPatternSame(sequence, samePatternIndex, checkStartIndex, sequenceLength);
			}

			return foundPattern;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static bool IsPatternSame([NotNull] T[] sequence, int leftPatternIndex, int rightPatternIndex,
			int sequenceLength)
		{
			bool isSame = true;

			for (; isSame & rightPatternIndex < sequenceLength; ++leftPatternIndex, ++rightPatternIndex)
			{
				isSame = s_comparer.Equals(sequence[leftPatternIndex], sequence[rightPatternIndex]);
			}

			return isSame;
		}
	}
}
