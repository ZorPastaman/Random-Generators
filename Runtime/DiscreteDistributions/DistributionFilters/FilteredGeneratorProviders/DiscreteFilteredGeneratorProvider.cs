// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class DiscreteFilteredGeneratorProvider<T> : DiscreteGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGenerator;
		[SerializeField] private DiscreteFilterProviderReference[] m_Filters;
#pragma warning restore CS0649

		private DiscreteFilteredGenerator<T> m_sharedFilteredGenerator;
		private IDiscreteFilter<T>[] m_filtersCache;

		public sealed override IDiscreteGenerator<T> generator
		{
			[Pure]
			get => new DiscreteFilteredGenerator<T>(m_FilteredGenerator.GetGenerator<T>(), filters);
		}

		public sealed override IDiscreteGenerator<T> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedFilteredGenerator == null)
				{
					m_sharedFilteredGenerator = filteredGenerator;
				}

				return m_sharedFilteredGenerator;
			}
		}

		[NotNull]
		public DiscreteFilteredGenerator<T> filteredGenerator
		{
			[Pure]
			get => new DiscreteFilteredGenerator<T>(m_FilteredGenerator.GetGenerator<T>(), filters);
		}

		[NotNull]
		public DiscreteFilteredGenerator<T> sharedFilteredGenerator
		{
			[Pure]
			get
			{
				if (m_sharedFilteredGenerator == null)
				{
					m_sharedFilteredGenerator = filteredGenerator;
				}

				return m_sharedFilteredGenerator;
			}
		}

		[NotNull]
		private IDiscreteFilter<T>[] filters
		{
			[Pure]
			get
			{
				if (m_filtersCache == null)
				{
					int filtersCount = m_Filters.Length;
					m_filtersCache = new IDiscreteFilter<T>[filtersCount];

					for (int i = 0; i < filtersCount; ++i)
					{
						m_filtersCache[i] = m_Filters[i].GetFilter<T>();
					}
				}

				return m_filtersCache;
			}
		}
	}
}
