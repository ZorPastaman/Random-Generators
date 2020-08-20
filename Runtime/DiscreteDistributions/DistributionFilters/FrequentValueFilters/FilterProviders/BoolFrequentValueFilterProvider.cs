// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Bool Frequent Value Filter Provider",
		fileName = "Bool Frequent Value Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolFrequentValueFilterProvider : FrequentValueFilterProvider<bool>
	{
	}
}
