// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceFiltersFolder + "Int Extreme Sequence Filter Provider",
		fileName = "Int Extreme Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntExtremeSequenceFilterProvider : DiscreteFilterProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private IntExtremeSequenceFilter m_ExtremeSequenceFilter;
#pragma warning restore CS0649

		public override IDisceteFilter<int> filter
		{
			[Pure]
			get => new IntExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		public override IDisceteFilter<int> sharedFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}

		[NotNull]
		public IntExtremeSequenceFilter extremeSequenceFilter
		{
			[Pure]
			get => new IntExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		[NotNull]
		public IntExtremeSequenceFilter sharedExtremeSequenceFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}
	}
}
