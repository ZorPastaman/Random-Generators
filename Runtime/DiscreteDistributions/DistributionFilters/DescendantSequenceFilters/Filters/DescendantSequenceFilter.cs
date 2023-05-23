// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a descendant sequence
	/// of the specified length.
	/// </summary>
	public sealed class DescendantSequenceFilter<T> : IDescendantSequenceFilter<T> where T : IComparable<T>
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_descendantSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_descendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_descendantSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return DescendantSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_descendantSequenceLength);
		}
	}
}
