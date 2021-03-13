// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a descendant sequence
	/// of the specified length.
	/// </summary>
	[Serializable]
	public sealed class DescendantSequenceFilter : IDescendantSequenceFilter
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed descendant sequence length.")]
		private byte m_DescendantSequenceLength = DescendantSequenceFiltering.DefaultDescendantSequenceLength;
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DescendantSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_DescendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DescendantSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return DescendantSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				descendantSequenceLength);
		}
	}
}
