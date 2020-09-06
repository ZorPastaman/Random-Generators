// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="BoolFilteredGenerator{T}"/>.
	/// </summary>
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

		private BoolFilteredGenerator<IDiscreteGenerator<bool>> m_sharedFilteredGenerator;
		private IDiscreteFilter<bool>[] m_filtersCache;

		/// <summary>
		/// Creates a new <see cref="BoolFilteredGenerator{T}"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolFilteredGenerator<IDiscreteGenerator<bool>>(
				m_FilteredGenerator.GetGenerator<bool>(), filters);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolFilteredGenerator{T}"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
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
		/// Creates a new <see cref="BoolFilteredGenerator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolFilteredGenerator<IDiscreteGenerator<bool>> filteredGenerator
		{
			[Pure]
			get => new BoolFilteredGenerator<IDiscreteGenerator<bool>>(
				m_FilteredGenerator.GetGenerator<bool>(), filters);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolFilteredGenerator{T}"/>.
		/// </summary>
		[NotNull]
		public BoolFilteredGenerator<IDiscreteGenerator<bool>> sharedFilteredGenerator
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
		private IDiscreteFilter<bool>[] filters
		{
			get
			{
				if (m_filtersCache == null)
				{
					int filtersCount = m_Filters.Length;
					m_filtersCache = new IDiscreteFilter<bool>[filtersCount];

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
