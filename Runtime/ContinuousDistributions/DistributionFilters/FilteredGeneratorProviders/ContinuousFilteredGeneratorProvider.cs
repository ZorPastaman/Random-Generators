// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		fileName = "ContinuousFilteredGeneratorProvider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class ContinuousFilteredGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_FilteredGeneratorProvider;
		[SerializeField] private ContinuousFilterProviderReference[] m_FilterProviders;
		[SerializeField, Tooltip("How many times a value may be regenerated.")]
		private byte m_RegenerateAttempts = 3;
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
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(
				m_FilteredGeneratorProvider.generator, filters, m_RegenerateAttempts);
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
			get => new ContinuousFilteredGenerator<IContinuousGenerator>(
				m_FilteredGeneratorProvider.generator, filters, m_RegenerateAttempts);
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

		public ContinuousGeneratorProviderReference filteredGeneratorProvider
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
		/// How many times a value may be regenerated.
		/// </summary>
		public byte regenerateAttempts
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_RegenerateAttempts;
			set
			{
				if (m_RegenerateAttempts == value)
				{
					return;
				}

				m_RegenerateAttempts = value;
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
		/// Returns a <see cref="ContinuousFilterProviderReference"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="ContinuousFilterProviderReference"/> at the index <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public ContinuousFilterProviderReference GetFilter(int index)
		{
			return m_FilterProviders[index];
		}

		/// <summary>
		/// Sets the filter <paramref name="filterProvider"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="filterProvider"></param>
		/// <param name="index"></param>
		public void SetFilter(ContinuousFilterProviderReference filterProvider, int index)
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
		public void SetFilters([NotNull] ContinuousFilterProviderReference[] filterProviders)
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
		private IContinuousFilter[] filters
		{
			get
			{
				if (m_filtersCache == null)
				{
					int count = m_FilterProviders.Length;
					m_filtersCache = new IContinuousFilter[count];

					for (int i = 0; i < count; ++i)
					{
						m_filtersCache[i] = m_FilterProviders[i].filter;
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
