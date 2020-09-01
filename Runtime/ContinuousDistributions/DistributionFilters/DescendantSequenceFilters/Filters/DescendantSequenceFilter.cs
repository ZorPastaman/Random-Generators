// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a descendant sequence
	/// of the length <see cref="m_DescendantSequenceLength"/>.
	/// </summary>
	[Serializable]
	public sealed class DescendantSequenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed descendant sequence length.")]
		private byte m_DescendantSequenceLength = 3;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> with the default parameters.
		/// </summary>
		public DescendantSequenceFilter()
		{
		}

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="descendantSequenceLength">
		/// Allowed descendant sequence length.
		/// </param>
		public DescendantSequenceFilter(byte descendantSequenceLength)
		{
			m_DescendantSequenceLength = descendantSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public DescendantSequenceFilter([NotNull] DescendantSequenceFilter other)
		{
			m_DescendantSequenceLength = other.m_DescendantSequenceLength;
		}

		/// <summary>
		/// Allowed descendant sequence length.
		/// </summary>
		public byte descendantSequenceLength
		{
			[Pure]
			get => m_DescendantSequenceLength;
			set => m_DescendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_DescendantSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, descendantSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues
		/// the descendant sequence <paramref name="sequence"/> and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="descendantSequenceLength">Allowed descendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, byte sequenceLength,
			byte descendantSequenceLength)
		{
			bool descending = true;

			for (int i = sequenceLength - descendantSequenceLength + 1; descending & i < sequenceLength; ++i)
			{
				descending = sequence[i - 1] > sequence[i];
			}

			return descending & sequence[sequenceLength - 1] > newValue;
		}
	}
}
