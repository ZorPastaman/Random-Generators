// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms the same pattern in a sequence
	/// as a pattern before it.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class SamePatternFilter<T> : ISamePatternFilter<T> where T : IEquatable<T>
	{
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_patternLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_patternLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (byte)(m_patternLength * 2 - 1);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return SamePatternFiltering.NeedRegenerate(sequence, newValue, sequenceLength, m_patternLength);
		}
	}
}
