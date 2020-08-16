// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Bool Filtered Generator Provider",
		fileName = "Bool Filtered Generator Provider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
		)]
	public sealed class BoolFilteredGeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGenerator;
		[SerializeField, RequireDiscreteFilter(typeof(bool))] private DiscreteFilterProviderReference[] m_Filters;
#pragma warning restore CS0649

		private BoolFilteredGenerator m_sharedFilteredGenerator;
		private IDisceteFilter<bool>[] m_filtersCache;

		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolFilteredGenerator(m_FilteredGenerator.GetGenerator<bool>(), filters);
		}

		public override IDiscreteGenerator<bool> sharedGenerator
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
		public BoolFilteredGenerator filteredGenerator
		{
			[Pure]
			get => new BoolFilteredGenerator(m_FilteredGenerator.GetGenerator<bool>(), filters);
		}

		[NotNull]
		public BoolFilteredGenerator sharedFilteredGenerator
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
		private IDisceteFilter<bool>[] filters
		{
			[Pure]
			get
			{
				if (m_filtersCache == null)
				{
					int filtersCount = m_Filters.Length;
					m_filtersCache = new IDisceteFilter<bool>[filtersCount];

					for (int i = 0; i < filtersCount; ++i)
					{
						m_filtersCache[i] = m_Filters[i].GetFilter<bool>();
					}
				}

				return m_filtersCache;
			}
		}
	}
}
