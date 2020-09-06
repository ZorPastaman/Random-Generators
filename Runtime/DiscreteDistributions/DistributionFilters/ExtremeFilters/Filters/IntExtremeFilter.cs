// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to an expected minimum or maximum.
	/// </summary>
	[Serializable]
	public sealed class IntExtremeFilter : IDiscreteFilter<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_ExpectedMin;
		[SerializeField] private int m_ExpectedMax = 10;
		[SerializeField,
		Tooltip("How far from an expected minimum or maximum a value may be to be counted as close enough.")]
		private uint m_Range = 5;
		[SerializeField, Tooltip("Allowed extreme sequence length.")]
		private byte m_ExtremeSequenceLength = 6;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="IntExtremeFilter"/> with the default parameters.
		/// </summary>
		public IntExtremeFilter()
		{
		}

		/// <summary>
		/// Creates an <see cref="IntExtremeFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="expectedMin"></param>
		/// <param name="expectedMax"></param>
		/// <param name="range">
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </param>
		/// <param name="extremeSequenceLength">Allowed extreme sequence length.</param>
		public IntExtremeFilter(int expectedMin, int expectedMax, uint range, byte extremeSequenceLength)
		{
			m_ExpectedMin = expectedMin;
			m_ExpectedMax = expectedMax;
			m_Range = range;
			m_ExtremeSequenceLength = extremeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public IntExtremeFilter([NotNull] IntExtremeFilter other)
		{
			m_ExpectedMin = other.m_ExpectedMin;
			m_ExpectedMax = other.m_ExpectedMax;
			m_Range = other.m_Range;
			m_ExtremeSequenceLength = other.m_ExtremeSequenceLength;
		}

		public int expectedMin
		{
			[Pure]
			get => m_ExpectedMin;
			set => m_ExpectedMin = value;
		}

		public int expectedMax
		{
			[Pure]
			get => m_ExpectedMax;
			set => m_ExpectedMax = value;
		}

		/// <summary>
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </summary>
		public uint range
		{
			[Pure]
			get => m_Range;
			set => m_Range = value;
		}

		/// <summary>
		/// Allowed extreme sequence length.
		/// </summary>
		public byte extremeSequenceLength
		{
			[Pure]
			get => m_ExtremeSequenceLength;
			set => m_ExtremeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_ExtremeSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(int[] sequence, int newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_ExpectedMin, m_ExpectedMax, m_Range,
				sequenceLength, m_ExtremeSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the extreme sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="expectedMin"></param>
		/// <param name="expectedMax"></param>
		/// <param name="range">
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="extremeSequenceLength">Allowed extreme sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] int[] sequence, int newValue, int expectedMin, int expectedMax,
			uint range, byte sequenceLength, byte extremeSequenceLength)
		{
			int extreme;

			if (newValue < expectedMin + range)
			{
				extreme = expectedMin;
			}
			else if (newValue > expectedMax - range)
			{
				extreme = expectedMax;
			}
			else
			{
				return false;
			}

			bool inRange = true;

			for (int i = sequenceLength - extremeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - extreme) < range;
			}

			return inRange;
		}
	}
}
