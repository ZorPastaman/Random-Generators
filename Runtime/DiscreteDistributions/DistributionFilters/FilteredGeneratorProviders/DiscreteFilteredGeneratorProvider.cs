// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		[SerializeField] private DiscreteGeneratorProviderReference m_FilteredGenerator;
		[SerializeField] private DiscreteFilterProviderReference[] m_Filters;
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
				m_FilteredGenerator.GetGenerator<T>(), filters);
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
				m_FilteredGenerator.GetGenerator<T>(), filters);
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

		/// <summary>
		/// <para>Filters cache.</para>
		/// <para>
		/// Filters cache is created from <see cref="m_Filters"/> when this property is called for the first time.
		/// </para>
		/// </summary>
		[NotNull]
		private IDiscreteFilter<T>[] filters
		{
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
