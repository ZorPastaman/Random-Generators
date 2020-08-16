// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class DiscreteFilteredGenerator<T> : IDiscreteGenerator<T>
	{
		[NotNull] private IDiscreteGenerator<T> m_filteredGenerator;
		[NotNull] private IDisceteFilter<T>[] m_filters;

		private T[] m_sequence;
		private byte m_currentSequenceLength;

		public DiscreteFilteredGenerator([NotNull] IDiscreteGenerator<T> filteredGenerator,
			[NotNull] params IDisceteFilter<T>[] filters)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
		}

		public DiscreteFilteredGenerator([NotNull] DiscreteFilteredGenerator<T> other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
		}

		[NotNull]
		public IDiscreteGenerator<T> filteredGenerator
		{
			[Pure]
			get => m_filteredGenerator;
			set => m_filteredGenerator = value;
		}

		[NotNull]
		public IDisceteFilter<T>[] filters
		{
			[Pure]
			get => m_filters;
			set
			{
				m_filters = value;
				InitializeSequence();
			}
		}

		public T Generate()
		{
			T generated;

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
			byte sequenceLength = 0;

			for (int i = 0, count = m_filters.Length; i < count; ++i)
			{
				sequenceLength = Math.Max(sequenceLength, m_filters[i].requiredSequenceLength);
			}

			m_sequence = new T[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
