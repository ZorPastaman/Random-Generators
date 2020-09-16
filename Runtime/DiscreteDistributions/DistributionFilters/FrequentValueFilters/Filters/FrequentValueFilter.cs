// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if the same value is contained in a sequence
	/// more than allowed times.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class FrequentValueFilter<T> : IFrequentValueFilter<T> where T : IEquatable<T>
	{
		private byte m_controlledSequenceLength;
		private byte m_allowedRepeats;

		/// <summary>
		/// Creates a <see cref="FrequentValueFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="allowedRepeats"></param>
		public FrequentValueFilter(byte controlledSequenceLength, byte allowedRepeats)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_allowedRepeats = allowedRepeats;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public FrequentValueFilter([NotNull] FrequentValueFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_allowedRepeats = other.m_allowedRepeats;
		}

		public byte controlledSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_controlledSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_controlledSequenceLength = value;
		}

		public byte allowedRepeats
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_allowedRepeats;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_allowedRepeats = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_controlledSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return FrequentValueFiltering.NeedRegenerate(sequence, newValue, sequenceLength, m_controlledSequenceLength,
				m_allowedRepeats);
		}
	}
}
