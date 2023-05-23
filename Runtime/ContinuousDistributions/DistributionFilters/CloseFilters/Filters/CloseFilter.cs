// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to a reference value.
	/// </summary>
	public sealed class CloseFilter : ICloseFilter
	{
		private float m_referenceValue;
		private float m_range;
		private byte m_closeSequenceLength;

		/// <summary>
		/// Creates a new <see cref="CloseFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from a reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		public CloseFilter(float referenceValue, float range, byte closeSequenceLength)
		{
			m_referenceValue = referenceValue;
			m_range = range;
			m_closeSequenceLength = closeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public CloseFilter([NotNull] CloseFilter other)
		{
			m_referenceValue = other.m_referenceValue;
			m_range = other.m_range;
			m_closeSequenceLength = other.m_closeSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_referenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_referenceValue = value;
		}

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		public float range
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_range;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_range = value;
		}

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		public byte closeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_closeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_closeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_closeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return CloseFiltering.NeedRegenerate(sequence, newValue, m_referenceValue, m_range, sequenceLength,
				m_closeSequenceLength);
		}
	}
}
