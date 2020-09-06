// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SamePatternDiscreteFiltersFolder + "Int Same Pattern Discrete Filter",
		fileName = "Int Same Pattern Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntSamePatternFilterProvider : SamePatterFilterProvider<int>
	{
	}
}
