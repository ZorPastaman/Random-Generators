// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues an ascendant sequence
	/// of the specified length.
	/// </summary>
	[Serializable]
	public sealed class AscendantSequenceFilter : IAscendantSequenceFilter
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed ascendant sequence length.")]
		private byte m_AscendantSequenceLength = AscendantSequenceFiltering.DefaultAscendantSequenceLength;
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_AscendantSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_AscendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_AscendantSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return AscendantSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_AscendantSequenceLength);
		}
	}
}
