// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DescendantSequenceFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceDiscreteFiltersFolder +
			"Bool Descendant Sequence Filter Provider",
		fileName = "BoolDescendantSequenceFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolDescendantSequenceFilterProvider : DescendantSequenceFilterProvider<bool>
	{
	}
}
