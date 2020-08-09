// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class FilteredGeneratorProvider<T> : DiscreteGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGenerator;
		[SerializeField] private DiscreteFilterProviderReference[] m_Filters;
#pragma warning restore CS0649

		private FilteredGenerator<T> m_sharedFilteredGenerator;
		private IFilter<T>[] m_filtersCache;

		public sealed override IDiscreteGenerator<T> generator
		{
			[Pure]
			get => new FilteredGenerator<T>(m_FilteredGenerator.GetGenerator<T>(), filters);
		}

		public sealed override IDiscreteGenerator<T> sharedGenerator
		{
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
		public FilteredGenerator<T> filteredGenerator
		{
			[Pure]
			get => new FilteredGenerator<T>(m_FilteredGenerator.GetGenerator<T>(), filters);
		}

		public FilteredGenerator<T> sharedFilteredGenerator
		{
			get
			{
				if (m_sharedFilteredGenerator == null)
				{
					m_sharedFilteredGenerator = filteredGenerator;
				}

				return m_sharedFilteredGenerator;
			}
		}

		private IFilter<T>[] filters
		{
			get
			{
				if (m_filtersCache == null)
				{
					int filtersCount = m_Filters.Length;
					m_filtersCache = new IFilter<T>[filtersCount];

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
