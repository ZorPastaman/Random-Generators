// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="TValue"></typeparam>
	/// <typeparam name="TGenerator"></typeparam>
	public sealed class DiscreteFilteredGenerator<TValue, TGenerator> : IDiscreteFilteredGenerator<TValue, TGenerator>
		where TGenerator : IDiscreteGenerator<TValue>
	{
		[NotNull] private TGenerator m_filteredGenerator;
		[NotNull] private IDiscreteFilter<TValue>[] m_filters;

		private TValue[] m_sequence;
		private byte m_currentSequenceLength;

		private byte m_regenerateAttempts;

		/// <summary>
		/// Creates a <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/> with the specified parameters.
		/// </summary>
		/// <param name="filteredGenerator"></param>
		/// <param name="filters"></param>
		/// <param name="regenerateAttempts">
		/// <para>How many times a value may be regenerated.</para>
		/// <para>If this value is exceeded, a last generated value is returned.</para>
		/// </param>
		public DiscreteFilteredGenerator([NotNull] TGenerator filteredGenerator,
			[NotNull] IDiscreteFilter<TValue>[] filters, byte regenerateAttempts)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
			m_regenerateAttempts = regenerateAttempts;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public DiscreteFilteredGenerator([NotNull] DiscreteFilteredGenerator<TValue, TGenerator> other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
			m_regenerateAttempts = other.m_regenerateAttempts;
		}

		[NotNull]
		public TGenerator filteredGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_filteredGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_filteredGenerator = value;
		}

		/// <summary>
		/// <para>How many times a value may be regenerated.</para>
		/// <para>If this value is exceeded, a last generated value is returned.</para>
		/// </summary>
		public byte regenerateAttempts
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_regenerateAttempts;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_regenerateAttempts = value;
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
		public IDiscreteFilter<TValue> GetFilter(int index)
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
		public void SetFilter([NotNull] IDiscreteFilter<TValue> filter, int index)
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
		public void SetFilters([NotNull] params IDiscreteFilter<TValue>[] filters)
		{
			int count = filters.Length;

			if (m_filters.Length != count)
			{
				m_filters = new IDiscreteFilter<TValue>[count];
			}

			Array.Copy(filters, 0, m_filters, 0, count);

			InitializeSequence();
		}

		/// <summary>
		/// Takes a generated value from its depended generator filtered with its filters.
		/// </summary>
		/// <returns>Filtered generated value.</returns>
		/// <remarks>
		/// The value is regenerated until all the filters approve it.
		/// </remarks>
		public TValue Generate()
		{
			TValue generated;
			byte currentRegenerateAttempts = 0;

			do
			{
				generated = m_filteredGenerator.Generate();
			} while (currentRegenerateAttempts++ < m_regenerateAttempts &&
				m_filters.NeedRegenerate(m_sequence, generated, m_currentSequenceLength));

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

			m_sequence = new TValue[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
