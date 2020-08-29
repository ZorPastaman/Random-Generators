// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.OppositePatterDiscreteFiltersFolder + "Bool Opposite Pattern Discrete Filter",
		fileName = "Bool Opposite Pattern Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolOppositePatternFilterProvider : DiscreteFilterProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private BoolOppositePatternFilter m_OppositePatternFilter;
#pragma warning restore CS0649

		private BoolOppositePatternFilter m_sharedFilter;

		public override IDiscreteFilter<bool> filter
		{
			[Pure]
			get => new BoolOppositePatternFilter(m_OppositePatternFilter);
		}

		public override IDiscreteFilter<bool> sharedFilter
		{
			[Pure]
			get => m_OppositePatternFilter;
		}

		[NotNull]
		public BoolOppositePatternFilter oppositePatternFilter
		{
			[Pure]
			get => new BoolOppositePatternFilter(m_OppositePatternFilter);
		}

		[NotNull]
		public BoolOppositePatternFilter sharedOppositePatternFilter
		{
			[Pure]
			get => m_OppositePatternFilter;
		}
	}
}
