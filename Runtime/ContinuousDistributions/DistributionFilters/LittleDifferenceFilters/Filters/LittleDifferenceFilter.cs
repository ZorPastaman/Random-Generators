// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where consecutive
	/// elements differ by less than the required difference.
	/// </summary>
	[Serializable]
	public sealed class LittleDifferenceFilter : ILittleDifferenceFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_RequiredDifference = LittleDifferenceFiltering.DefaultRequiredDifference;
		[SerializeField, Tooltip("Allowed little difference sequence length.")]
		private byte m_LittleDifferenceSequenceLength = LittleDifferenceFiltering.DefaultLittleDifferenceSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="LittleDifferenceFilter"/> with the default parameters.
		/// </summary>
		public LittleDifferenceFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="LittleDifferenceFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="requiredDifference"></param>
		/// <param name="littleDifferenceSequenceLength">Allowed little difference sequence length.</param>
		public LittleDifferenceFilter(float requiredDifference, byte littleDifferenceSequenceLength)
		{
			m_RequiredDifference = requiredDifference;
			m_LittleDifferenceSequenceLength = littleDifferenceSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public LittleDifferenceFilter([NotNull] LittleDifferenceFilter other)
		{
			m_RequiredDifference = other.m_RequiredDifference;
			m_LittleDifferenceSequenceLength = other.m_LittleDifferenceSequenceLength;
		}

		public float requiredDifference
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_RequiredDifference;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_RequiredDifference = value;
		}

		/// <summary>
		/// Allowed little difference sequence length.
		/// </summary>
		public byte littleDifferenceSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LittleDifferenceSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_LittleDifferenceSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LittleDifferenceSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return LittleDifferenceFiltering.NeedRegenerate(sequence, newValue, m_RequiredDifference, sequenceLength,
				m_LittleDifferenceSequenceLength);
		}
	}
}
