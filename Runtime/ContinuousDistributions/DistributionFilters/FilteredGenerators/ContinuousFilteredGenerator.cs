// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class ContinuousFilteredGenerator<T> : IContinuousGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_filteredGenerator;
		[NotNull] private IContinuousFilter[] m_filters;

		private float[] m_sequence;
		private byte m_currentSequenceLength;

		/// <summary>
		/// Creates a <see cref="ContinuousFilteredGenerator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="filteredGenerator"></param>
		/// <param name="filters"></param>
		public ContinuousFilteredGenerator([NotNull] T filteredGenerator,
			[NotNull] params IContinuousFilter[] filters)
		{
			m_filteredGenerator = filteredGenerator;
			m_filters = filters;
			InitializeSequence();
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
		}

		[NotNull]
		public T filteredGenerator
		{
			[Pure]
			get => m_filteredGenerator;
			set => m_filteredGenerator = value;
		}

		[NotNull]
		public IContinuousFilter[] filters
		{
			[Pure]
			get => m_filters;
			set
			{
				m_filters = value;
				InitializeSequence();
			}
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

			m_sequence = new float[sequenceLength];
			m_currentSequenceLength = 0;
		}
	}
}
