// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is in range.
	/// </summary>
	[Serializable]
	public sealed class InRangeFilter : IInRangeFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = InRangeFiltering.DefaultMin;
		[SerializeField] private float m_Max = InRangeFiltering.DefaultMax;
		[SerializeField, Tooltip("Allowed in range sequence length.")]
		private byte m_InRangeSequenceLength = InRangeFiltering.DefaultInRangeSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="InRangeFilter"/> with the default parameters.
		/// </summary>
		public InRangeFilter()
		{
		}

		/// <summary>
		/// Creates an <see cref="InRangeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="inRangeSequenceLength">Allowed in range sequence length.</param>
		public InRangeFilter(float min, float max, byte inRangeSequenceLength)
		{
			m_Min = min;
			m_Max = max;
			m_InRangeSequenceLength = inRangeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public InRangeFilter([NotNull] InRangeFilter other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
			m_InRangeSequenceLength = other.m_InRangeSequenceLength;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Max = value;
		}

		/// <summary>
		/// Allowed in range sequence length.
		/// </summary>
		public byte inRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InRangeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_InRangeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InRangeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return InRangeFiltering.NeedRegenerate(sequence, newValue, m_Min, m_Max, sequenceLength,
				m_InRangeSequenceLength);
		}
	}
}
