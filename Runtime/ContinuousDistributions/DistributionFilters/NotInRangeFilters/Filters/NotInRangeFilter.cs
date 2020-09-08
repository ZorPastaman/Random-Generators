// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is not in range.
	/// </summary>
	[Serializable]
	public sealed class NotInRangeFilter : IContinuousFilter
	{
		public const float DefaultMin = -1f;
		public const float DefaultMax = 1f;
		public const byte DefaultNotInRangeSequenceLength = 3;

#pragma warning disable CS0649
		[SerializeField] private float m_Min = DefaultMin;
		[SerializeField] private float m_Max = DefaultMax;
		[SerializeField, Tooltip("Allowed not in range sequence length.")]
		private byte m_NotInRangeSequenceLength = DefaultNotInRangeSequenceLength;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="NotInRangeFilter"/> with the default parameters.
		/// </summary>
		public NotInRangeFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="NotInRangeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="notInRangeSequenceLength">Allowed not in range sequence length.</param>
		public NotInRangeFilter(float min, float max, byte notInRangeSequenceLength)
		{
			m_Min = min;
			m_Max = max;
			m_NotInRangeSequenceLength = notInRangeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NotInRangeFilter([NotNull] NotInRangeFilter other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
			m_NotInRangeSequenceLength = other.m_NotInRangeSequenceLength;
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
		/// Allowed not in range sequence length.
		/// </summary>
		public byte notInRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_NotInRangeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_NotInRangeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_NotInRangeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_Min, m_Max, sequenceLength, m_NotInRangeSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the not in range sequence
		/// <paramref name="sequence"/> and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="notInRangeSequenceLength">Allowed not in range sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float min, float max,
			byte sequenceLength, byte notInRangeSequenceLength)
		{
			bool inWrongRange = true;

			for (int i = sequenceLength - notInRangeSequenceLength; inWrongRange & i < sequenceLength; ++i)
			{
				float value = sequence[i];
				inWrongRange = min > value | max < value;
			}

			return inWrongRange & (min > newValue | max < newValue);
		}
	}
}
