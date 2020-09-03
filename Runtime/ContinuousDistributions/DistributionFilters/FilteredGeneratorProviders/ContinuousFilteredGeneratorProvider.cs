// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="ContinuousFilteredGenerator{IContinuousGenerator}"/>.
	/// </summary>
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

		/// <summary>
		/// Creates a new <see cref="ContinuousFilteredGenerator{IContinuousGenerator}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(m_FilteredGenerator.generator, filters);
		}

		/// <summary>
		/// Returns a shared <see cref="ContinuousFilteredGenerator{IContinuousGenerator}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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

		/// <summary>
		/// Creates a new <see cref="ContinuousFilteredGenerator{IContinuousGenerator}"/> and returns it.
		/// </summary>
		[NotNull]
		public ContinuousFilteredGenerator<IContinuousGenerator> filteredGenerator
		{
			[Pure]
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(m_FilteredGenerator.generator, filters);
		}

		/// <summary>
		/// Returns a shared <see cref="ContinuousFilteredGenerator{IContinuousGenerator}"/>.
		/// </summary>
		[NotNull]
		public ContinuousFilteredGenerator<IContinuousGenerator> sharedFilteredGenerator
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

		/// <summary>
		/// <para>Filters cache.</para>
		/// <para>
		/// Filters cache is created from <see cref="m_Filters"/> when this property is called for the first time.
		/// </para>
		/// </summary>
		[NotNull]
		private IContinuousFilter[] filters
		{
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
