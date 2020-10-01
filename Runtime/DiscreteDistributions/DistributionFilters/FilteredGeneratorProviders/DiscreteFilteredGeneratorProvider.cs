// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/>.
	/// </summary>
	public abstract class DiscreteFilteredGeneratorProvider<T> : DiscreteGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGeneratorProvider;
		[SerializeField] private DiscreteFilterProviderReference[] m_FilterProviders;
		[SerializeField, Tooltip("How many times a value may be regenerated.")]
		private byte m_RegenerateAttempts = 3;
#pragma warning restore CS0649

		private DiscreteFilteredGenerator<T, IDiscreteGenerator<T>> m_sharedFilteredGenerator;
		private IDiscreteFilter<T>[] m_filtersCache;

		/// <summary>
		/// Creates a new <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public sealed override IDiscreteGenerator<T> generator
		{
			[Pure]
			get => new DiscreteFilteredGenerator<T, IDiscreteGenerator<T>>(
				m_FilteredGeneratorProvider.GetGenerator<T>(), filters, m_RegenerateAttempts);
		}

		/// <summary>
		/// Returns a shared <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/>
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
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

		/// <summary>
		/// Creates a new <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/> and returns it.
		/// </summary>
		[NotNull]
		public DiscreteFilteredGenerator<T, IDiscreteGenerator<T>> filteredGenerator
		{
			[Pure]
			get => new DiscreteFilteredGenerator<T, IDiscreteGenerator<T>>(
				m_FilteredGeneratorProvider.GetGenerator<T>(), filters, m_RegenerateAttempts);
		}

		/// <summary>
		/// Returns a shared <see cref="DiscreteFilteredGenerator{TValue,TGenerator}"/>.
		/// </summary>
		[NotNull]
		public DiscreteFilteredGenerator<T, IDiscreteGenerator<T>> sharedFilteredGenerator
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
		private IDiscreteFilter<T>[] filters
		{
			get
			{
				if (m_filtersCache == null)
				{
					int count = m_FilterProviders.Length;
					m_filtersCache = new IDiscreteFilter<T>[count];

					for (int i = 0; i < count; ++i)
					{
						m_filtersCache[i] = m_FilterProviders[i].GetFilter<T>();
					}
				}

				return m_filtersCache;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sealed override void DropSharedGenerator()
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
