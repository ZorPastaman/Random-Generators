// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class DiscreteFilteredGenerator<TValue, TGenerator> : IDiscreteGenerator<TValue>
		where TGenerator : IDiscreteGenerator<TValue>
	{
		[NotNull] private TGenerator m_filteredGenerator;
		[NotNull] private IDiscreteFilter<TValue>[] m_filters;

		private TValue[] m_sequence;
		private byte m_currentSequenceLength;

		public DiscreteFilteredGenerator([NotNull] TGenerator filteredGenerator,
			[NotNull] params IDiscreteFilter<TValue>[] filters)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
		}

		public DiscreteFilteredGenerator([NotNull] DiscreteFilteredGenerator<TValue, TGenerator> other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
		}

		[NotNull]
		public TGenerator filteredGenerator
		{
			[Pure]
			get => m_filteredGenerator;
			set => m_filteredGenerator = value;
		}

		public int filtersCount
		{
			[Pure]
			get => m_filters.Length;
		}

		[NotNull, Pure]
		public IDiscreteFilter<TValue> GetFilter(int index)
		{
			return m_filters[index];
		}

		public void SetFilter([NotNull] IDiscreteFilter<TValue> filter, int index)
		{
			m_filters[index] = filter;
			InitializeSequence();
		}

		public void SetFilters([NotNull] params IDiscreteFilter<TValue>[] filters)
		{
			m_filters = filters;
			InitializeSequence();
		}

		public TValue Generate()
		{
			TValue generated;

			do
			{
				generated = m_filteredGenerator.Generate();
			} while (m_filters.NeedRegenerate(m_sequence, generated, m_currentSequenceLength));

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
