// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DescendantSequenceFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceDiscreteFiltersFolder +
			"Int Descendant Sequence Filter Provider",
		fileName = "IntDescendantSequenceFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntDescendantSequenceFilterProvider : DescendantSequenceFilterProvider<int>
	{
	}
}
