// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues an ascendant sequence
	/// of the specified length.
	/// </summary>
	public sealed class AscendantSequenceFilter : IAscendantSequenceFilter
	{
		private byte m_ascendantSequenceLength;

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="ascendantSequenceLength">
		/// Allowed ascendant sequence length.
		/// </param>
		public AscendantSequenceFilter(byte ascendantSequenceLength)
		{
			m_ascendantSequenceLength = ascendantSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public AscendantSequenceFilter([NotNull] AscendantSequenceFilter other)
		{
			m_ascendantSequenceLength = other.m_ascendantSequenceLength;
		}

		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		public byte ascendantSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ascendantSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ascendantSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ascendantSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			return AscendantSequenceFiltering.NeedRegenerate(sequence, newValue, sequenceLength,
				m_ascendantSequenceLength);
		}
	}
}
