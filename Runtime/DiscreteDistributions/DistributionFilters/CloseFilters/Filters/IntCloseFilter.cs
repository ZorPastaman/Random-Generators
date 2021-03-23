// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to a reference value.
	/// </summary>
	public sealed class IntCloseFilter : ICloseFilter<int>
	{
		public const int DefaultReferenceValue = 0;
		public const int DefaultRange = 4;
		public const byte DefaultCloseSequenceLength = 6;

		private int m_referenceValue;
		private int m_range;
		private byte m_closeSequenceLength;

		/// <summary>
		/// Creates an <see cref="IntCloseFilter"/> with the specified parameters.
		/// </summary>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from a reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		public IntCloseFilter(int referenceValue, int range, byte closeSequenceLength)
		{
			m_referenceValue = referenceValue;
			m_range = range;
			m_closeSequenceLength = closeSequenceLength;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public IntCloseFilter([NotNull] IntCloseFilter other)
		{
			m_referenceValue = other.m_referenceValue;
			m_range = other.m_range;
			m_closeSequenceLength = other.m_closeSequenceLength;
		}

		public int referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_referenceValue;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_referenceValue = value;
		}

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		public int range
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_range;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_range = value;
		}

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		public byte closeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_closeSequenceLength;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_closeSequenceLength = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_closeSequenceLength;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool NeedRegenerate(int[] sequence, int newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, m_referenceValue, m_range, sequenceLength, m_closeSequenceLength);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is close enough to the reference value <paramref name="referenceValue"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from a reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] int[] sequence, int newValue, int referenceValue, int range,
			byte sequenceLength, byte closeSequenceLength)
		{
			bool inRange = true;

			for (int i = sequenceLength - closeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - referenceValue) < range;
			}

			return inRange & Mathf.Abs(newValue - referenceValue) < range;
		}
	}
}
