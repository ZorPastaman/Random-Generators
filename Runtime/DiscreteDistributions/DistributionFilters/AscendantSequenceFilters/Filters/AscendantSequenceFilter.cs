// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues an ascendant sequence
	/// of the specified length.
	/// </summary>
	public sealed class AscendantSequenceFilter<T> : IAscendantSequenceFilter<T> where T : IComparable<T>
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ascendantSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ascendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ascendantSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return AscendantSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_ascendantSequenceLength);
		}
	}
}
