// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues an ascendant sequence
	/// of the specified length.
	/// </summary>
	public sealed class AscendantSequenceFilter<T> : IDiscreteFilter<T> where T : IComparable<T>
	{
		private byte m_ascendantSequenceLength;

		/// <summary>
		/// Creates an <see cref="AscendantSequenceFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="ascendantSequenceLength">Allowed ascendant sequence length.</param>
		public AscendantSequenceFilter(byte ascendantSequenceLength)
		{
			m_ascendantSequenceLength = ascendantSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public AscendantSequenceFilter([NotNull] AscendantSequenceFilter<T> other)
		{
			m_ascendantSequenceLength = other.m_ascendantSequenceLength;
		}

		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		public byte ascendantSequenceLength
		{
			[Pure]
			get => m_ascendantSequenceLength;
			set => m_ascendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_ascendantSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_ascendantSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the ascendant sequence <paramref name="sequence"/>
		/// and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="ascendantSequenceLength">Allowed ascendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] T[] sequence, T newValue, byte sequenceLength,
			byte ascendantSequenceLength)
		{
			bool ascending = true;

			for (int i = sequenceLength - ascendantSequenceLength + 1; ascending & i < sequenceLength; ++i)
			{
				ascending = sequence[i - 1].CompareTo(sequence[i]) < 0;
			}

			return ascending & sequence[sequenceLength - 1].CompareTo(newValue) < 0;
		}
	}
}
