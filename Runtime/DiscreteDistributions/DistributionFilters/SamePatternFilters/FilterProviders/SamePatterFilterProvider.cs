// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class SamePatterFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_MaxSamePatternLength;
#pragma warning restore CS0649

		private SamePatternFilter<T> m_sharedFilter;

		public sealed override IDisceteFilter<T> filter
		{
			[Pure]
			get => new SamePatternFilter<T>(m_MaxSamePatternLength);
		}

		public sealed override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = sameSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		[NotNull]
		public SamePatternFilter<T> sameSequenceFilter
		{
			[Pure]
			get => new SamePatternFilter<T>(m_MaxSamePatternLength);
		}

		[NotNull]
		public SamePatternFilter<T> sharedSameSequenceFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = sameSequenceFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
