// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it forms a pattern opposite to a previous pattern.
	/// </summary>
	/// <example>
	/// { false, false, false, true, true, true } - last value is regenerated.
	/// </example>
	[Serializable]
	public sealed class BoolOppositePatternFilter : IDiscreteFilter<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_PatternLength = 3;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="BoolOppositePatternFilter"/> with the default parameters.
		/// </summary>
		public BoolOppositePatternFilter()
		{
		}

		/// <summary>
		/// Creates a <see cref="BoolOppositePatternFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="patternLength"></param>
		public BoolOppositePatternFilter(byte patternLength)
		{
			m_PatternLength = patternLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BoolOppositePatternFilter([NotNull] BoolOppositePatternFilter other)
		{
			m_PatternLength = other.m_PatternLength;
		}

		public byte patternLength
		{
			[Pure]
			get => m_PatternLength;
			set => m_PatternLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => (byte)(m_PatternLength * 2 - 1);
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(bool[] sequence, bool newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_PatternLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> forms a pattern opposite to a previous pattern.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="patternLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] bool[] sequence, bool newValue, byte sequenceLength,
			byte patternLength)
		{
			if (sequence[sequenceLength - patternLength] == newValue)
			{
				return false;
			}

			bool nonOppositePattern = false;

			for (int i = sequenceLength - patternLength * 2 + 1, j = sequenceLength - patternLength + 1;
				!nonOppositePattern & j < sequenceLength;
				++i, ++j)
			{
				nonOppositePattern = sequence[i] == sequence[j];
			}

			return !nonOppositePattern;
		}
	}
}
