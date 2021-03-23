// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is not in range.
	/// </summary>
	public sealed class NotInRangeFilter : INotInRangeFilter
	{
		private float m_min;
		private float m_max;
		private byte m_notInRangeSequenceLength;

		/// <summary>
		/// Creates a <see cref="NotInRangeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="notInRangeSequenceLength">Allowed not in range sequence length.</param>
		public NotInRangeFilter(float min, float max, byte notInRangeSequenceLength)
		{
			m_min = min;
			m_max = max;
			m_notInRangeSequenceLength = notInRangeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NotInRangeFilter([NotNull] NotInRangeFilter other)
		{
			m_min = other.m_min;
			m_max = other.m_max;
			m_notInRangeSequenceLength = other.m_notInRangeSequenceLength;
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
		/// Allowed not in range sequence length.
		/// </summary>
		public byte notInRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_notInRangeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_notInRangeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_notInRangeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NotInRangeFiltering.NeedRegenerate(sequence, newValue, m_min, m_max, sequenceLength,
				m_notInRangeSequenceLength);
		}
	}
}
