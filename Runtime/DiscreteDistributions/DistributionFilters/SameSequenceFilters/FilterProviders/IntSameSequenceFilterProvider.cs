// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SameSequenceFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Int Same Sequence Filter",
		fileName = "Int Same Sequence Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntSameSequenceFilterProvider : SameSequenceFilterProvider<int>
	{
	}
}
