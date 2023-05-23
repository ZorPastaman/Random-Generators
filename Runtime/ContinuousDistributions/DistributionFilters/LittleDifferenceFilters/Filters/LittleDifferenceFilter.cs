// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where consecutive
	/// elements differ by less than the required difference.
	/// </summary>
	public sealed class LittleDifferenceFilter : ILittleDifferenceFilter
	{
		private float m_requiredDifference;
		private byte m_littleDifferenceSequenceLength;

		/// <summary>
		/// Creates a <see cref="LittleDifferenceFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="requiredDifference"></param>
		/// <param name="littleDifferenceSequenceLength">Allowed little difference sequence length.</param>
		public LittleDifferenceFilter(float requiredDifference, byte littleDifferenceSequenceLength)
		{
			m_requiredDifference = requiredDifference;
			m_littleDifferenceSequenceLength = littleDifferenceSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public LittleDifferenceFilter([NotNull] LittleDifferenceFilter other)
		{
			m_requiredDifference = other.m_requiredDifference;
			m_littleDifferenceSequenceLength = other.m_littleDifferenceSequenceLength;
		}

		public float requiredDifference
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_requiredDifference;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_requiredDifference = value;
		}

		/// <summary>
		/// Allowed little difference sequence length.
		/// </summary>
		public byte littleDifferenceSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_littleDifferenceSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_littleDifferenceSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_littleDifferenceSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return LittleDifferenceFiltering.NeedRegenerate(sequence, newValue, m_requiredDifference, sequenceLength,
				m_littleDifferenceSequenceLength);
		}
	}
}
