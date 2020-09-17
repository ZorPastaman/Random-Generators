// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to a reference value.
	/// </summary>
	[Serializable]
	public sealed class CloseFilter : ICloseFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = CloseFiltering.DefaultReferenceValue;
		[SerializeField,
		Tooltip("How far from a reference value a value may be to be counted as close enough.")]
		private float m_Range = CloseFiltering.DefaultRange;
		[SerializeField, Tooltip("Allowed close sequence length.")]
		private byte m_CloseSequenceLength = CloseFiltering.DefaultCloseSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="CloseFilter"/> with the default parameters.
		/// </summary>
		public CloseFilter()
		{
		}

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
			m_ReferenceValue = referenceValue;
			m_Range = range;
			m_CloseSequenceLength = closeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public CloseFilter([NotNull] CloseFilter other)
		{
			m_ReferenceValue = other.m_ReferenceValue;
			m_Range = other.m_Range;
			m_CloseSequenceLength = other.m_CloseSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ReferenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ReferenceValue = value;
		}

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		public float range
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Range;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Range = value;
		}

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		public byte closeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_CloseSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_CloseSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_CloseSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return CloseFiltering.NeedRegenerate(sequence, newValue, m_ReferenceValue, m_Range, sequenceLength,
				m_CloseSequenceLength);
		}
	}
}
