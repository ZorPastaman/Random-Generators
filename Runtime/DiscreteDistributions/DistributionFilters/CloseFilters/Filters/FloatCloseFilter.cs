// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to a reference value.
	/// </summary>
	[Serializable]
	public sealed class FloatCloseFilter : ICloseFilter<float>
	{
		public const float DefaultReferenceValue = 0f;
		public const float DefaultRange = 5f;
		public const byte DefaultCloseSequenceLength = 6;

#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = DefaultReferenceValue;
		[SerializeField,
		Tooltip("How far from a reference value a value may be to be counted as close enough.")]
		private float m_Range = DefaultRange;
		[SerializeField, Tooltip("Allowed close sequence length.")]
		private byte m_CloseSequenceLength = DefaultCloseSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="FloatCloseFilter"/> with the default parameters.
		/// </summary>
		public FloatCloseFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="FloatCloseFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from a reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		public FloatCloseFilter(float referenceValue, float range, byte closeSequenceLength)
		{
			m_ReferenceValue = referenceValue;
			m_Range = range;
			m_CloseSequenceLength = closeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public FloatCloseFilter([NotNull] FloatCloseFilter other)
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
			return NeedRegenerate(sequence, newValue, m_ReferenceValue, m_Range, sequenceLength, m_CloseSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is close enough to the reference value <paramref name="referenceValue"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from a reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float referenceValue, float range,
			byte sequenceLength, byte closeSequenceLength)
		{
			bool inRange = true;

			for (int i = sequenceLength - closeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - referenceValue) < range;
			}

			return inRange & Mathf.Abs(newValue - referenceValue) < range;
		}
	}
}
