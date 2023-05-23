// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence
	/// of the specified length where every value is the same.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class SameSequenceFilter<T> : ISameSequenceFilter<T> where T : IEquatable<T>
	{
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_allowedSameSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_allowedSameSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_allowedSameSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return SameSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_allowedSameSequenceLength);
		}
	}
}
