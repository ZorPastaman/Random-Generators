// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public sealed class BoolFilteredGenerator : IDiscreteGenerator<bool>
	{
		[NotNull] private IDiscreteGenerator<bool> m_filteredGenerator;
		[NotNull] private IDisceteFilter<bool>[] m_filters;

		private bool[] m_sequence;
		private byte m_currentSequenceLength;

		public BoolFilteredGenerator([NotNull] IDiscreteGenerator<bool> filteredGenerator,
			[NotNull] params IDisceteFilter<bool>[] filters)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
		}

		public BoolFilteredGenerator([NotNull] BoolFilteredGenerator other)
		{
			m_filteredGenerator = other.m_filteredGenerator;
			m_filters = other.m_filters;
			InitializeSequence();
		}

		[NotNull]
		public IDiscreteGenerator<bool> filteredGenerator
		{
			[Pure]
			get => m_filteredGenerator;
			set => m_filteredGenerator = value;
		}

		[NotNull]
		public IDisceteFilter<bool>[] filters
		{
			[Pure]
			get => m_filters;
			set
			{
				m_filters = value;
				InitializeSequence();
			}
		}

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
			byte sequenceLength = 0;

			for (int i = 0, count = m_filters.Length; i < count; ++i)
			{
				sequenceLength = Math.Max(sequenceLength, m_filters[i].requiredSequenceLength);
			}

			m_sequence = new bool[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
