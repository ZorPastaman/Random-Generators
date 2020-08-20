// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class FrequentValueFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength;
		[SerializeField] private byte m_AllowedRepeats;
#pragma warning restore CS0649

		private FrequentValueFilter<T> m_sharedFilter;

		public sealed override IDisceteFilter<T> filter
		{
			[Pure]
			get => new FrequentValueFilter<T>(m_ControlledSequenceLength, m_AllowedRepeats);
		}

		public sealed override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = frequentValueFilter;
				}

				return m_sharedFilter;
			}
		}

		[NotNull]
		public FrequentValueFilter<T> frequentValueFilter
		{
			[Pure]
			get => new FrequentValueFilter<T>(m_ControlledSequenceLength, m_AllowedRepeats);
		}

		[NotNull]
		public FrequentValueFilter<T> sharedFrequentValueFilter
		{
			[Pure]
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
