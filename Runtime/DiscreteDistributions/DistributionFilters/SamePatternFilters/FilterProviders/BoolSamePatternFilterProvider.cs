// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SamePatternDiscreteFiltersFolder + "Bool Same Pattern Filter",
		fileName = "BoolSamePatternFilter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolSamePatternFilterProvider : SamePatterFilterProvider<bool>
	{
	}
}
