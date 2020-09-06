// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SamePatternDiscreteFiltersFolder + "Bool Same Pattern Discrete Filter",
		fileName = "Bool Same Pattern Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolSamePatternFilterProvider : SamePatterFilterProvider<bool>
	{
	}
}
