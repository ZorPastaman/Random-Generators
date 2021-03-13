// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		private byte m_requiredSequenceLength;

		/// <summary>
		/// Creates a <see cref="SamePatternFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="patternLength"></param>
		public SamePatternFilter(byte patternLength)
		{
			m_patternLength = patternLength;
			ComputeRequiredSequenceLength();
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SamePatternFilter([NotNull] SamePatternFilter<T> other)
		{
			m_patternLength = other.m_patternLength;
			m_requiredSequenceLength = other.m_requiredSequenceLength;
		}

		public byte patternLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_patternLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_patternLength = value;
				ComputeRequiredSequenceLength();
			}
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_requiredSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return SamePatternFiltering.NeedRegenerate(sequence, newValue, sequenceLength, m_patternLength);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ComputeRequiredSequenceLength()
		{
			m_requiredSequenceLength = (byte)(m_patternLength * 2 - 1);
		}
	}
}
