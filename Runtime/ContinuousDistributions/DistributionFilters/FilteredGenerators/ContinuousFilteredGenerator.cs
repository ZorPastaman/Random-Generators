// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class ContinuousFilteredGenerator<T> : IContinuousFilteredGenerator<T> where T : IContinuousGenerator
	{
		[NotNull] private T m_filteredGenerator;
		[NotNull] private IContinuousFilter[] m_filters;

		private float[] m_sequence;
		private byte m_currentSequenceLength;

		private byte m_regenerateAttempts;

		/// <summary>
		/// Creates a <see cref="ContinuousFilteredGenerator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="filteredGenerator"></param>
		/// <param name="filters"></param>
		/// <param name="regenerateAttempts">
		/// <para>How many times a value may be regenerated.</para>
		/// <para>If this value is exceeded, a last generated value is returned.</para>
		/// </param>
		public ContinuousFilteredGenerator([NotNull] T filteredGenerator,
			[NotNull] IContinuousFilter[] filters, byte regenerateAttempts)
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
		public ContinuousFilteredGenerator([NotNull] ContinuousFilteredGenerator<T> other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
			m_regenerateAttempts = other.m_regenerateAttempts;
		}

		[NotNull]
		public T filteredGenerator
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
		/// Returns a <see cref="IContinuousFilter"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="IContinuousFilter"/> at the index <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, Pure]
		public IContinuousFilter GetFilter(int index)
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
		public void SetFilter([NotNull] IContinuousFilter filter, int index)
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
		public void SetFilters([NotNull] params IContinuousFilter[] filters)
		{
			m_filters = filters;
			InitializeSequence();
		}

		/// <summary>
		/// Takes a generated value from its depended generator filtered with its filters.
		/// </summary>
		/// <returns>Filtered generated value.</returns>
		/// <remarks>
		/// The value is regenerated until all the filters approve it.
		/// </remarks>
		public float Generate()
		{
			float generated;
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

			m_sequence = new float[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
