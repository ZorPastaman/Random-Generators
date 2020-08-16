// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Int Same Sequence Discrete Filter",
		fileName = "Int Same Sequence Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntSameSequenceFilterProvider : SameSequenceFilterProvider<int>
	{
	}
}
