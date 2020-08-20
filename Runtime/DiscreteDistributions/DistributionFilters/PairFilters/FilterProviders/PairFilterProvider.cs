// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class PairFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ElementsBetweenPair;
#pragma warning restore CS0649

		private PairFilter<T> m_sharedFilter;

		public sealed override IDisceteFilter<T> filter
		{
			[Pure]
			get => new PairFilter<T>(m_ElementsBetweenPair);
		}

		public sealed override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = pairFilter;
				}

				return m_sharedFilter;
			}
		}

		[NotNull]
		public PairFilter<T> pairFilter
		{
			[Pure]
			get => new PairFilter<T>(m_ElementsBetweenPair);
		}

		[NotNull]
		public PairFilter<T> sharedPairFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = pairFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
