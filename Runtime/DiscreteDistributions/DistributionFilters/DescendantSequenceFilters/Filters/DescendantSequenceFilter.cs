// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a descendant sequence
	/// of the specified length.
	/// </summary>
	public sealed class DescendantSequenceFilter<T> : IDiscreteFilter<T> where T : IComparable<T>
	{
		private byte m_descendantSequenceLength;

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="descendantSequenceLength">
		/// Allowed descendant sequence length.
		/// </param>
		public DescendantSequenceFilter(byte descendantSequenceLength)
		{
			m_descendantSequenceLength = descendantSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public DescendantSequenceFilter([NotNull] DescendantSequenceFilter<T> other)
		{
			m_descendantSequenceLength = other.m_descendantSequenceLength;
		}

		/// <summary>
		/// Allowed descendant sequence length.
		/// </summary>
		public byte descendantSequenceLength
		{
			[Pure]
			get => m_descendantSequenceLength;
			set => m_descendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_descendantSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_descendantSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues
		/// the descendant sequence <paramref name="sequence"/> and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="descendantSequenceLength">Allowed descendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] T[] sequence, T newValue, byte sequenceLength,
			byte descendantSequenceLength)
		{
			bool descending = true;

			for (int i = sequenceLength - descendantSequenceLength + 1; descending & i < sequenceLength; ++i)
			{
				descending = sequence[i - 1].CompareTo(sequence[i]) > 0;
			}

			return descending & sequence[sequenceLength - 1].CompareTo(newValue) > 0;
		}
	}
}
