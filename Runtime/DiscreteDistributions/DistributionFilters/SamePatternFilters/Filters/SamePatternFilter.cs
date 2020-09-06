// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms the same pattern in a sequence
	/// as a pattern before it.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class SamePatternFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_patternLength;

		/// <summary>
		/// Creates a <see cref="SamePatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="patternLength"></param>
		public SamePatternFilter(byte patternLength)
		{
			m_patternLength = patternLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SamePatternFilter([NotNull] SamePatternFilter<T> other)
		{
			m_patternLength = other.m_patternLength;
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
			get => (byte)(m_patternLength * 2 - 1);
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_patternLength);
		}

		/// <summary>
		/// Checks if the value <paramref cref="newValue"/> forms the same pattern
		/// in the sequence <paramref name="sequence"/> as a pattern before.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="patternLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte patternLength)
		{
			bool samePattern = true;

			for (int i = sequenceLength - patternLength * 2 + 1, j = sequenceLength - patternLength + 1;
				samePattern & j < sequenceLength;
				++i, ++j)
			{
				samePattern = s_comparer.Equals(sequence[i], sequence[j]);
			}

			return samePattern && s_comparer.Equals(sequence[sequenceLength - patternLength], newValue);
		}
	}
}
