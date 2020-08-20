// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceDiscreteFiltersFolder +
			"Bool Descendant Sequence Filter Provider",
		fileName = "Bool Descendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolDescendantSequenceFilterProvider : DescendantSequenceFilterProvider<bool>
	{
	}
}
