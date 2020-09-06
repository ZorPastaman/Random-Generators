// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if a sequence has the same value some elements before.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class PairFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_elementsBetweenPair;

		/// <summary>
		/// Creates a <see cref="PairFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="elementsBetweenPair"></param>
		public PairFilter(byte elementsBetweenPair)
		{
			m_elementsBetweenPair = elementsBetweenPair;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PairFilter([NotNull] PairFilter<T> other)
		{
			m_elementsBetweenPair = other.m_elementsBetweenPair;
		}

		public byte elementsBetweenPair
		{
			[Pure]
			get => m_elementsBetweenPair;
			set => m_elementsBetweenPair = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => (byte)(m_elementsBetweenPair + 1);
		}

		/// <inheritdoc/>
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_elementsBetweenPair);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> is contained in the sequence <paramref name="sequence"/>
		/// <paramref name="elementsBetweenPair"/> elements before and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="elementsBetweenPair"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte elementsBetweenPair)
		{
			return s_comparer.Equals(sequence[sequenceLength - elementsBetweenPair - 1], newValue);
		}
	}
}
