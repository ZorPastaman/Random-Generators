// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms a pattern the same to a pattern
	/// some elements before.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class RepeatingPatternFilter<T> : IRepeatingPatternFilter<T> where T : IEquatable<T>
	{
		private byte m_controlledSequenceLength;
		private byte m_patternLength;

		/// <summary>
		/// Creates a <see cref="RepeatingPatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="patternLength"></param>
		public RepeatingPatternFilter(byte controlledSequenceLength, byte patternLength)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_patternLength = patternLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RepeatingPatternFilter([NotNull] RepeatingPatternFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_patternLength = other.m_patternLength;
		}

		public byte controlledSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_controlledSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_controlledSequenceLength = value;
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
			get => m_controlledSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return RepeatingPatternFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_controlledSequenceLength, m_patternLength);
		}
	}
}
