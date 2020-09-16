// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms a pattern opposite to a previous pattern.
	/// </summary>
	/// <remarks>
	/// Type <typeparamref name="T"/> must take only two values like <see cref="bool"/>.
	/// </remarks>
	public sealed class OppositePatternFilter<T> : IOppositePatternFilter<T> where T : IEquatable<T>
	{
		private byte m_patternLength;

		/// <summary>
		/// Creates an <see cref="OppositePatternFilter{T}"/> with the default parameters.
		/// </summary>
		public OppositePatternFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="OppositePatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="patternLength"></param>
		public OppositePatternFilter(byte patternLength)
		{
			m_patternLength = patternLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public OppositePatternFilter([NotNull] OppositePatternFilter<T> other)
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
			return OppositePatternFiltering.NeedRegenerate(sequence, newValue, sequenceLength, m_patternLength);
		}
	}
}
