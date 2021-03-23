// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is in range.
	/// </summary>
	public sealed class InRangeFilter : IInRangeFilter
	{
		private float m_min;
		private float m_max;
		private byte m_inRangeSequenceLength;

		/// <summary>
		/// Creates an <see cref="InRangeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="inRangeSequenceLength">Allowed in range sequence length.</param>
		public InRangeFilter(float min, float max, byte inRangeSequenceLength)
		{
			m_min = min;
			m_max = max;
			m_inRangeSequenceLength = inRangeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public InRangeFilter([NotNull] InRangeFilter other)
		{
			m_min = other.m_min;
			m_max = other.m_max;
			m_inRangeSequenceLength = other.m_inRangeSequenceLength;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <summary>
		/// Allowed in range sequence length.
		/// </summary>
		public byte inRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_inRangeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_inRangeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_inRangeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return InRangeFiltering.NeedRegenerate(sequence, newValue, m_min, m_max, sequenceLength,
				m_inRangeSequenceLength);
		}
	}
}
