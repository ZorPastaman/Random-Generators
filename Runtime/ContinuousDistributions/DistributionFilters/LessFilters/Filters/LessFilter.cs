// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is less
	/// than the specified reference value.
	/// </summary>
	[Serializable]
	public sealed class LessFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue;
		[SerializeField, Tooltip("Allowed less sequence length.")]
		private byte m_LessSequenceLength = 3;
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
			[Pure]
			get => m_ReferenceValue;
			set => m_ReferenceValue = value;
		}

		/// <summary>
		/// Allowed less sequence length.
		/// </summary>
		public byte lessSequenceLength
		{
			[Pure]
			get => m_LessSequenceLength;
			set => m_LessSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_LessSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_ReferenceValue, sequenceLength, m_LessSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the less sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="lessSequenceLength">Allowed less sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float referenceValue,
			byte sequenceLength, byte lessSequenceLength)
		{
			bool greater = true;

			for (int i = sequenceLength - lessSequenceLength; greater & i < sequenceLength; ++i)
			{
				greater = sequence[i] < referenceValue;
			}

			return greater & newValue < referenceValue;
		}
	}
}
