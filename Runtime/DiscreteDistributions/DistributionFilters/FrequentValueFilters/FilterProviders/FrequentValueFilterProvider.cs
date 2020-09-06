// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class FrequentValueFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength = 2;
		[SerializeField] private byte m_AllowedRepeats = 1;
#pragma warning restore CS0649

		private FrequentValueFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="FrequentValueFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new FrequentValueFilter<T>(m_ControlledSequenceLength, m_AllowedRepeats);
		}

		/// <summary>
		/// Returns a shared <see cref="FrequentValueFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = frequentValueFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="FrequentValueFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public FrequentValueFilter<T> frequentValueFilter
		{
			[Pure]
			get => new FrequentValueFilter<T>(m_ControlledSequenceLength, m_AllowedRepeats);
		}

		/// <summary>
		/// Returns a shared <see cref="FrequentValueFilter{T}"/>.
		/// </summary>
		[NotNull]
		public FrequentValueFilter<T> sharedFrequentValueFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = frequentValueFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
