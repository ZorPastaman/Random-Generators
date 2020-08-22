// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousFilteredGeneratorsFolder +
			"Continuous Filtered Generator Provider",
		fileName = "Continuous Filtered Generator Provider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class ContinuousFilteredGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_FilteredGenerator;
		[SerializeField] private ContinuousFilterProviderReference[] m_Filters;
#pragma warning restore CS0649

		private ContinuousFilteredGenerator<IContinuousGenerator> m_sharedFilteredGenerator;
		private IContinuousFilter[] m_filtersCache;

		public override IContinuousGenerator generator
		{
			[Pure]
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(m_FilteredGenerator.generator, filters);
		}

		public override IContinuousGenerator sharedGenerator
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
		public ContinuousFilteredGenerator<IContinuousGenerator> filteredGenerator
		{
			[Pure]
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(m_FilteredGenerator.generator, filters);
		}

		[NotNull]
		public ContinuousFilteredGenerator<IContinuousGenerator> sharedFilteredGenerator
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
		private IContinuousFilter[] filters
		{
			[Pure]
			get
			{
				if (m_filtersCache == null)
				{
					int filtersCount = m_Filters.Length;
					m_filtersCache = new IContinuousFilter[filtersCount];

					for (int i = 0; i < filtersCount; ++i)
					{
						m_filtersCache[i] = m_Filters[i].filter;
					}
				}

				return m_filtersCache;
			}
		}
	}
}
