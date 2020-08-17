// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class DescendantSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IComparable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_DescendantSequenceLength;
#pragma warning restore CS0649

		private DescendantSequenceFilter<T> m_sharedFilter;

		public override IDisceteFilter<T> filter
		{
			[Pure]
			get => new DescendantSequenceFilter<T>(m_DescendantSequenceLength);
		}

		public override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = descendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		[NotNull]
		public DescendantSequenceFilter<T> descendantSequenceFilter
		{
			[Pure]
			get => new DescendantSequenceFilter<T>(m_DescendantSequenceLength);
		}

		[NotNull]
		public DescendantSequenceFilter<T> sharedDescendantSequenceFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = descendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
