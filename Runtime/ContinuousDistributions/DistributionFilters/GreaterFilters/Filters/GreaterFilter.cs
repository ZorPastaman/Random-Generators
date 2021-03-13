// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is greater
	/// than the specified reference value.
	/// </summary>
	[Serializable]
	public sealed class GreaterFilter : IGreaterFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = GreaterFiltering.DefaultReferenceValue;
		[SerializeField, Tooltip("Allowed greater sequence length.")]
		private byte m_GreaterSequenceLength = GreaterFiltering.DefaultGreaterSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="GreaterFilter"/> with the default parameters.
		/// </summary>
		public GreaterFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="GreaterFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="greaterSequenceLength">Allowed greater sequence length.</param>
		public GreaterFilter(float referenceValue, byte greaterSequenceLength)
		{
			m_ReferenceValue = referenceValue;
			m_GreaterSequenceLength = greaterSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GreaterFilter([NotNull] GreaterFilter other)
		{
			m_ReferenceValue = other.m_ReferenceValue;
			m_GreaterSequenceLength = other.m_GreaterSequenceLength;
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ReferenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ReferenceValue = value;
		}

		/// <summary>
		/// Allowed greater sequence length.
		/// </summary>
		public byte greaterSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_GreaterSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_GreaterSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_GreaterSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return GreaterFiltering.NeedRegenerate(sequence, newValue, m_ReferenceValue, sequenceLength,
				m_GreaterSequenceLength);
		}
	}
}
