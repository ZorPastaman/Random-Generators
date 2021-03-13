// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is less
	/// than the specified reference value.
	/// </summary>
	[Serializable]
	public sealed class LessFilter : ILessFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = LessFiltering.DefaultReferenceValue;
		[SerializeField, Tooltip("Allowed less sequence length.")]
		private byte m_LessSequenceLength = LessFiltering.DefaultLessSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="LessFilter"/> with the default parameters.
		/// </summary>
		public LessFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="LessFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="lessSequenceLength">Allowed less sequence length.</param>
		public LessFilter(float referenceValue, byte lessSequenceLength)
		{
			m_ReferenceValue = referenceValue;
			m_LessSequenceLength = lessSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public LessFilter([NotNull] LessFilter other)
		{
			m_ReferenceValue = other.m_ReferenceValue;
			m_LessSequenceLength = other.m_LessSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ReferenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ReferenceValue = value;
		}

		/// <summary>
		/// Allowed less sequence length.
		/// </summary>
		public byte lessSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LessSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_LessSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LessSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return LessFiltering.NeedRegenerate(sequence, newValue, m_ReferenceValue, sequenceLength,
				m_LessSequenceLength);
		}
	}
}
