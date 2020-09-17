// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class BoolFilteredGenerator<T> : IDiscreteFilteredGenerator<bool, T>
		where T : IDiscreteGenerator<bool>
	{
		[NotNull] private T m_filteredGenerator;
		[NotNull] private IDiscreteFilter<bool>[] m_filters;

		private bool[] m_sequence;
		private byte m_currentSequenceLength;

		/// <summary>
		/// Creates a <see cref="BoolFilteredGenerator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="filteredGenerator"></param>
		/// <param name="filters"></param>
		public BoolFilteredGenerator([NotNull] T filteredGenerator, [NotNull] params IDiscreteFilter<bool>[] filters)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BoolFilteredGenerator([NotNull] BoolFilteredGenerator<T> other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
		}

		[NotNull]
		public T filteredGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_filteredGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_filteredGenerator = value;
		}

		public byte regenerateAttempts
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => 0;
		}

		/// <summary>
		/// How many filters are used by this generator.
		/// </summary>
		public int filtersCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_filters.Length;
		}

		/// <summary>
		/// Returns an <see cref="IDiscreteFilter{T}"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="IDiscreteFilter{T}"/> at the index <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, Pure]
		public IDiscreteFilter<bool> GetFilter(int index)
		{
			return m_filters[index];
		}

		/// <summary>
		/// Sets the filter <paramref name="filter"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="index"></param>
		/// <remarks>
		/// Current sequence of generated values is cleared by this method.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFilter([NotNull] IDiscreteFilter<bool> filter, int index)
		{
			m_filters[index] = filter;
			InitializeSequence();
		}

		/// <summary>
		/// Sets the set of filters <paramref name="filters"/>.
		/// </summary>
		/// <param name="filters"></param>
		/// <remarks>
		/// Current sequence of generated values is cleared by this method.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFilters([NotNull] params IDiscreteFilter<bool>[] filters)
		{
			m_filters = filters;
			InitializeSequence();
		}

		/// <summary>
		/// Takes a generated value from its depended generator filtered with its filters.
		/// </summary>
		/// <returns>Filtered generated value.</returns>
		/// <remarks>
		/// The value is flipped if at least one filter doesn't approve a value.
		/// </remarks>
		public bool Generate()
		{
			bool generated = m_filteredGenerator.Generate();

			if (m_filters.NeedRegenerate(m_sequence, generated, m_currentSequenceLength))
			{
				generated = !generated;
			}

			if (m_sequence.Length > m_currentSequenceLength)
			{
				m_sequence[m_currentSequenceLength++] = generated;
			}
			else
			{
				int last = m_currentSequenceLength - 1;
				Array.Copy(m_sequence, 1, m_sequence, 0, last);
				m_sequence[last] = generated;
			}

			return generated;
		}

		private void InitializeSequence()
		{
			byte sequenceLength = 1;

			for (int i = 0, count = m_filters.Length; i < count; ++i)
			{
				sequenceLength = Math.Max(sequenceLength, m_filters[i].requiredSequenceLength);
			}

			m_sequence = new bool[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
