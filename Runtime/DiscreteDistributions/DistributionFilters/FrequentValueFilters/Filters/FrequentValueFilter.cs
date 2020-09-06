// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if the same value is contained in a sequence
	/// more than allowed times.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class FrequentValueFilter<T> : IDiscreteFilter<T>
	{
		private static readonly EqualityComparer<T> s_comparer = EqualityComparer<T>.Default;

		private byte m_controlledSequenceLength;
		private byte m_allowedRepeats;

		/// <summary>
		/// Creates a <see cref="FrequentValueFilter{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="allowedRepeats"></param>
		public FrequentValueFilter(byte controlledSequenceLength, byte allowedRepeats)
		{
			m_controlledSequenceLength = controlledSequenceLength;
			m_allowedRepeats = allowedRepeats;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public FrequentValueFilter([NotNull] FrequentValueFilter<T> other)
		{
			m_controlledSequenceLength = other.m_controlledSequenceLength;
			m_allowedRepeats = other.m_allowedRepeats;
		}

		public byte controlledSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
			set => m_controlledSequenceLength = value;
		}

		public byte allowedRepeats
		{
			[Pure]
			get => m_allowedRepeats;
			set => m_allowedRepeats = value;
		}

		/// <inheritdoc/>
		public byte requiredSequenceLength
		{
			[Pure]
			get => m_controlledSequenceLength;
		}

		/// <inheritdoc/>
		[Pure]
		public bool NeedRegenerate(T[] sequence, T newValue, byte sequenceLength)
		{
			return NeedRegenerate(sequence, newValue, sequenceLength, m_controlledSequenceLength, m_allowedRepeats);
		}

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> is contained in the sequence <paramref name="sequence"/>
		/// more than allowed times <paramref name="allowedRepeats"/> and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="allowedRepeats"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static unsafe bool NeedRegenerate([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte controlledSequenceLength, byte allowedRepeats)
		{
			byte repeats = 0;

			for (int i = sequenceLength - controlledSequenceLength; i < sequenceLength; ++i)
			{
				bool equal = s_comparer.Equals(sequence[i], newValue);
				repeats += *(byte*)&equal;
			}

			return repeats > allowedRepeats;
		}
	}
}
