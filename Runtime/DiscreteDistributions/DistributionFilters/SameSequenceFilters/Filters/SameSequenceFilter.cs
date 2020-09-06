// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence
	/// of the specified length where every value is the same.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class SameSequenceFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_allowedSameSequenceLength;

		/// <summary>
		/// Creates a <see cref="SamePatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="allowedSameSequenceLength"></param>
		public SameSequenceFilter(byte allowedSameSequenceLength)
		{
			m_allowedSameSequenceLength = allowedSameSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SameSequenceFilter([NotNull] SameSequenceFilter<T> other)
		{
			m_allowedSameSequenceLength = other.m_allowedSameSequenceLength;
		}

		public byte allowedSameSequenceLength
		{
			[Pure]
			get => m_allowedSameSequenceLength;
			set => m_allowedSameSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_allowedSameSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_allowedSameSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is the same and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="allowedSameSequenceLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte allowedSameSequenceLength)
		{
			bool same = true;

			for (int i = sequenceLength - allowedSameSequenceLength; same & i < sequenceLength; ++i)
			{
				same = s_comparer.Equals(sequence[i], newValue);
			}

			return same;
		}
	}
}
