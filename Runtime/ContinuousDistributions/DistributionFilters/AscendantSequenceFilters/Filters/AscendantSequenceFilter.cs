// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues an ascendant sequence
	/// of the specified length.
	/// </summary>
	[Serializable]
	public sealed class AscendantSequenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed ascendant sequence length.")]
		private byte m_AscendantSequenceLength = 3;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter"/> with the default parameters.
		/// </summary>
		public AscendantSequenceFilter()
		{
		}

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="ascendantSequenceLength">
		/// Allowed ascendant sequence length.
		/// </param>
		public AscendantSequenceFilter(byte ascendantSequenceLength)
		{
			m_AscendantSequenceLength = ascendantSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public AscendantSequenceFilter([NotNull] AscendantSequenceFilter other)
		{
			m_AscendantSequenceLength = other.m_AscendantSequenceLength;
		}

		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		public byte ascendantSequenceLength
		{
			[Pure]
			get => m_AscendantSequenceLength;
			set => m_AscendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_AscendantSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_AscendantSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the ascendant sequence <paramref name="sequence"/>
		/// and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="ascendantSequenceLength">Allowed ascendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, byte sequenceLength,
			byte ascendantSequenceLength)
		{
			bool ascending = true;

			for (int i = sequenceLength - ascendantSequenceLength + 1; ascending & i < sequenceLength; ++i)
			{
				ascending = sequence[i - 1] < sequence[i];
			}

			return ascending & sequence[sequenceLength - 1] < newValue;
		}
	}
}
