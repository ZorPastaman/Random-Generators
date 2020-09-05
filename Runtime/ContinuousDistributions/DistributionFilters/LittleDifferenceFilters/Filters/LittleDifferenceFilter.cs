// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where consecutive
	/// elements differ by less than the required difference.
	/// </summary>
	[Serializable]
	public sealed class LittleDifferenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_RequiredDifference = 0.02f;
		[SerializeField, Tooltip("Allowed little difference sequence length.")]
		private byte m_LittleDifferenceSequenceLength = 2;
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
			[Pure]
			get => m_RequiredDifference;
			set => m_RequiredDifference = value;
		}

		/// <summary>
		/// Allowed little difference sequence length.
		/// </summary>
		public byte littleDifferenceSequenceLength
		{
			[Pure]
			get => m_LittleDifferenceSequenceLength;
			set => m_LittleDifferenceSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_LittleDifferenceSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_RequiredDifference, sequenceLength,
				m_LittleDifferenceSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where consecutive elements differ by less than the required difference <paramref name="requiredDifference"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="requiredDifference"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="littleDifferenceSequenceLength">Allowed little difference sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float requiredDifference,
			byte sequenceLength, byte littleDifferenceSequenceLength)
		{
			bool littleDifference = true;

			for (int i = sequenceLength - littleDifferenceSequenceLength + 1;
				littleDifference & i < sequenceLength;
				++i)
			{
				littleDifference = Mathf.Abs(sequence[i] - sequence[i - 1]) < requiredDifference;
			}

			return littleDifference & Mathf.Abs(newValue - sequence[sequenceLength - 1]) < requiredDifference;
		}
	}
}
