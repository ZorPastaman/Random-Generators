// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
	public sealed class GreaterFilter : IContinuousFilter
	{
		public const float DefaultReferenceValue = 0f;
		public const byte DefaultGreaterSequenceLength = 3;

#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = DefaultReferenceValue;
		[SerializeField, Tooltip("Allowed greater sequence length.")]
		private byte m_GreaterSequenceLength = DefaultGreaterSequenceLength;
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
			return NeedRegenerate(sequence, newValue, m_ReferenceValue, sequenceLength, m_GreaterSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the greater sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="greaterSequenceLength">Allowed greater sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float referenceValue,
			byte sequenceLength, byte greaterSequenceLength)
		{
			bool greater = true;

			for (int i = sequenceLength - greaterSequenceLength; greater & i < sequenceLength; ++i)
			{
				greater = sequence[i] > referenceValue;
			}

			return greater & newValue > referenceValue;
		}
	}
}
