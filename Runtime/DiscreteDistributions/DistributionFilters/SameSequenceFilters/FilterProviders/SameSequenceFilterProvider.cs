// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class SameSequenceFilterProvider<T> : FilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_MaxSameSequenceLength;
#pragma warning restore CS0649

		private SameSequenceFilter<T> m_sharedFilter;

		public override IFilter<T> filter
		{
			[Pure]
			get => new SameSequenceFilter<T>(m_MaxSameSequenceLength);
		}

		public override IFilter<T> sharedFilter
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
		public SameSequenceFilter<T> sameSequenceFilter
		{
			[Pure]
			get => new SameSequenceFilter<T>(m_MaxSameSequenceLength);
		}

		[NotNull]
		public SameSequenceFilter<T> sharedSameSequenceFilter
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
