// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class AscendantSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IComparable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_AscendantSequenceLength;
#pragma warning restore CS0649

		private AscendantSequenceFilter<T> m_sharedFilter;

		public override IDisceteFilter<T> filter
		{
			[Pure]
			get => new AscendantSequenceFilter<T>(m_AscendantSequenceLength);
		}

		public override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		[NotNull]
		public AscendantSequenceFilter<T> ascendantSequenceFilter
		{
			[Pure]
			get => new AscendantSequenceFilter<T>(m_AscendantSequenceLength);
		}

		[NotNull]
		public AscendantSequenceFilter<T> sharedAscendantSequenceFilter
		{
			[Pure]
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
