// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		fileName = "BoolFilteredGeneratorProvider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
		)]
	public sealed class BoolFilteredGeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGeneratorProvider;
		[SerializeField, RequireDiscreteFilter(typeof(bool))]
		private DiscreteFilterProviderReference[] m_FilterProviders;
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
				m_FilteredGeneratorProvider.GetGenerator<bool>(), filters);
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
				m_FilteredGeneratorProvider.GetGenerator<bool>(), filters);
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

		public DiscreteGeneratorProviderReference filteredGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_FilteredGeneratorProvider;
			set
			{
				if (m_FilteredGeneratorProvider == value)
				{
					return;
				}

				m_FilteredGeneratorProvider = value;
				m_sharedFilteredGenerator = null;
			}
		}

		/// <summary>
		/// How many filters are used by this provider.
		/// </summary>
		public int filtersCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_FilterProviders.Length;
		}

		/// <summary>
		/// Returns a <see cref="DiscreteFilterProviderReference"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="DiscreteFilterProviderReference"/> at the index <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public DiscreteFilterProviderReference GetFilter(int index)
		{
			return m_FilterProviders[index];
		}

		/// <summary>
		/// Sets the filter <paramref name="filterProvider"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="filterProvider"></param>
		/// <param name="index"></param>
		public void SetFilter(DiscreteFilterProviderReference filterProvider, int index)
		{
			if (m_FilterProviders[index] == filterProvider)
			{
				return;
			}

			m_FilterProviders[index] = filterProvider;
			m_sharedFilteredGenerator = null;
			m_filtersCache = null;
		}

		/// <summary>
		/// Sets the set of filters <paramref name="filterProviders"/>.
		/// </summary>
		/// <param name="filterProviders"></param>
		public void SetFilters([NotNull] DiscreteFilterProviderReference[] filterProviders)
		{
			if (m_FilterProviders == filterProviders)
			{
				return;
			}

			m_FilterProviders = filterProviders;
			m_sharedFilteredGenerator = null;
			m_filtersCache = null;
		}

		/// <summary>
		/// <para>Filters cache.</para>
		/// <para>
		/// Filters cache is created from <see cref="m_FilterProviders"/> when this property is called for the first time.
		/// </para>
		/// </summary>
		[NotNull]
		private IDiscreteFilter<bool>[] filters
		{
			get
			{
				if (m_filtersCache == null)
				{
					int count = m_FilterProviders.Length;
					m_filtersCache = new IDiscreteFilter<bool>[count];

					for (int i = 0; i < count; ++i)
					{
						m_filtersCache[i] = m_FilterProviders[i].GetFilter<bool>();
					}
				}

				return m_filtersCache;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedFilteredGenerator = null;
		}

		/// <summary>
		/// Drops a current filters cache so that a new filters cache is created on <see cref="filters"/>.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DropFiltersCache()
		{
			m_filtersCache = null;
		}

		private void OnValidate()
		{
			m_sharedFilteredGenerator = null;
			m_filtersCache = null;
		}
	}
}
