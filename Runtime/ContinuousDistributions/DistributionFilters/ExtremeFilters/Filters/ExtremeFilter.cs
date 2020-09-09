// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to an expected minimum or maximum.
	/// </summary>
	[Serializable]
	public sealed class ExtremeFilter : IExtremeFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ExpectedMin = ExtremeFiltering.DefaultExpectedMin;
		[SerializeField] private float m_ExpectedMax = ExtremeFiltering.DefaultExpectedMax;
		[SerializeField,
		Tooltip("How far from an expected minimum or maximum a value may be to be counted as close enough.")]
		private float m_Range = ExtremeFiltering.DefaultRange;
		[SerializeField, Tooltip("Allowed extreme sequence length.")]
		private byte m_ExtremeSequenceLength = ExtremeFiltering.DefaultExtremeSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> with the default parameters.
		/// </summary>
		public ExtremeFilter()
		{
		}

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="expectedMin"></param>
		/// <param name="expectedMax"></param>
		/// <param name="range">
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </param>
		/// <param name="extremeSequenceLength">Allowed extreme sequence length.</param>
		public ExtremeFilter(float expectedMin, float expectedMax, float range, byte extremeSequenceLength)
		{
			m_ExpectedMin = expectedMin;
			m_ExpectedMax = expectedMax;
			m_Range = range;
			m_ExtremeSequenceLength = extremeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExtremeFilter([NotNull] ExtremeFilter other)
		{
			m_ExpectedMin = other.m_ExpectedMin;
			m_ExpectedMax = other.m_ExpectedMax;
			m_Range = other.m_Range;
			m_ExtremeSequenceLength = other.m_ExtremeSequenceLength;
		}

		public float expectedMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExpectedMin;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ExpectedMin = value;
		}

		public float expectedMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExpectedMax;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ExpectedMax = value;
		}

		/// <summary>
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </summary>
		public float range
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Range;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Range = value;
		}

		/// <summary>
		/// Allowed extreme sequence length.
		/// </summary>
		public byte extremeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExtremeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ExtremeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExtremeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return ExtremeFiltering.NeedRegenerate(sequence, newValue, m_ExpectedMin, m_ExpectedMax, m_Range,
				sequenceLength, m_ExtremeSequenceLength);
		}
	}
}
