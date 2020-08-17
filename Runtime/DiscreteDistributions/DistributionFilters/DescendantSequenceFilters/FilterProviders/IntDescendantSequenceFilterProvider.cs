// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceFiltersFolder +
			"Int Descendant Sequence Filter Provider",
		fileName = "Int Descendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntDescendantSequenceFilterProvider : DescendantSequenceFilterProvider<int>
	{
	}
}
