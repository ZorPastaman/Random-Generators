// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SameSequenceFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Bool Same Sequence Filter",
		fileName = "BoolSameSequenceFilter",
		order = CreateAssetMenuConstants.FilterOrder
		)]
	public sealed class BoolSameSequenceFilterProvider : SameSequenceFilterProvider<bool>
	{
	}
}
