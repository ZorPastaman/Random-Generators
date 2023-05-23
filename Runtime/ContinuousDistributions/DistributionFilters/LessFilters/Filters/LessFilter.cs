// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is less
	/// than the specified reference value.
	/// </summary>
	public sealed class LessFilter : ILessFilter
	{
		private float m_referenceValue;
		private byte m_lessSequenceLength;

		/// <summary>
		/// Creates a <see cref="LessFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="lessSequenceLength">Allowed less sequence length.</param>
		public LessFilter(float referenceValue, byte lessSequenceLength)
		{
			m_referenceValue = referenceValue;
			m_lessSequenceLength = lessSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public LessFilter([NotNull] LessFilter other)
		{
			m_referenceValue = other.m_referenceValue;
			m_lessSequenceLength = other.m_lessSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_referenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_referenceValue = value;
		}

		/// <summary>
		/// Allowed less sequence length.
		/// </summary>
		public byte lessSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_lessSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_lessSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_lessSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return LessFiltering.NeedRegenerate(sequence, newValue, m_referenceValue, sequenceLength,
				m_lessSequenceLength);
		}
	}
}
