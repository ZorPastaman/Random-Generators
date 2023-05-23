// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is greater
	/// than the specified reference value.
	/// </summary>
	public sealed class GreaterFilter : IGreaterFilter
	{
		private float m_referenceValue;
		private byte m_greaterSequenceLength;

		/// <summary>
		/// Creates a <see cref="GreaterFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="greaterSequenceLength">Allowed greater sequence length.</param>
		public GreaterFilter(float referenceValue, byte greaterSequenceLength)
		{
			m_referenceValue = referenceValue;
			m_greaterSequenceLength = greaterSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GreaterFilter([NotNull] GreaterFilter other)
		{
			m_referenceValue = other.m_referenceValue;
			m_greaterSequenceLength = other.m_greaterSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_referenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_referenceValue = value;
		}

		/// <summary>
		/// Allowed greater sequence length.
		/// </summary>
		public byte greaterSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_greaterSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_greaterSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_greaterSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return GreaterFiltering.NeedRegenerate(sequence, newValue, m_referenceValue, sequenceLength,
				m_greaterSequenceLength);
		}
	}
}
