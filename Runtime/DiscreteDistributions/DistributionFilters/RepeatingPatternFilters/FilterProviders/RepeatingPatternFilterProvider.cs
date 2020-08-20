// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class RepeatingPatternFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength;
		[SerializeField] private byte m_PatternLength;
#pragma warning restore CS0649

		private RepeatingPatternFilter<T> m_sharedRepeatingPatternFilter;

		public sealed override IDisceteFilter<T> filter
		{
			[Pure]
			get => new RepeatingPatternFilter<T>(m_ControlledSequenceLength, m_PatternLength);
		}

		public sealed override IDisceteFilter<T> sharedFilter
		{
			[Pure]
			get
			{
				if (m_sharedRepeatingPatternFilter == null)
				{
					m_sharedRepeatingPatternFilter = repeatingPatternFilter;
				}

				return m_sharedRepeatingPatternFilter;
			}
		}

		[NotNull]
		public RepeatingPatternFilter<T> repeatingPatternFilter
		{
			[Pure]
			get => new RepeatingPatternFilter<T>(m_ControlledSequenceLength, m_PatternLength);
		}

		[NotNull]
		public RepeatingPatternFilter<T> sharedRepeatingPatternFilter
		{
			[Pure]
			get
			{
				if (m_sharedRepeatingPatternFilter == null)
				{
					m_sharedRepeatingPatternFilter = repeatingPatternFilter;
				}

				return m_sharedRepeatingPatternFilter;
			}
		}
	}
}
