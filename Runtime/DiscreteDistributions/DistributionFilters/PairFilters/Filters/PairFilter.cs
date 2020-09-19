// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if a sequence has the same value some elements before.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class PairFilter<T> : IPairFilter<T> where T : IEquatable<T>
	{
		private byte m_elementsBetweenPair;

		/// <summary>
		/// Creates a <see cref="PairFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="elementsBetweenPair"></param>
		public PairFilter(byte elementsBetweenPair)
		{
			m_elementsBetweenPair = elementsBetweenPair;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PairFilter([NotNull] PairFilter<T> other)
		{
			m_elementsBetweenPair = other.m_elementsBetweenPair;
		}

		public byte elementsBetweenPair
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_elementsBetweenPair;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_elementsBetweenPair = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (byte)(m_elementsBetweenPair + 1);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return PairFiltering.NeedRegenerate(sequence, newValue, sequenceLength, m_elementsBetweenPair);
		}
	}
}
