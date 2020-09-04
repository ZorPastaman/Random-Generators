// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is in range.
	/// </summary>
	[Serializable]
	public sealed class InRangeFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = -1f;
		[SerializeField] private float m_Max = 1f;
		[SerializeField, Tooltip("Allowed in range sequence length.")]
		private byte m_InRangeSequenceLength = 3;
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
			[Pure]
			get => m_Min;
			set => m_Min = value;
		}

		public float max
		{
			[Pure]
			get => m_Max;
			set => m_Max = value;
		}

		/// <summary>
		/// Allowed in range sequence length.
		/// </summary>
		public byte inRangeSequenceLength
		{
			[Pure]
			get => m_InRangeSequenceLength;
			set => m_InRangeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_InRangeSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_Min, m_Max, sequenceLength, m_InRangeSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the in range sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="inRangeSequenceLength">Allowed in range sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float min, float max,
			byte sequenceLength, byte inRangeSequenceLength)
		{
			bool inRange = true;

			for (int i = sequenceLength - inRangeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				float value = sequence[i];
				inRange = min <= value & max >= value;
			}

			return inRange & min <= newValue & max >= newValue;
		}
	}
}
