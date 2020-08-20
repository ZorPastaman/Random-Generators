// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder + 
			"Int Repeating Pattern Filter Provider",
		fileName = "Int Repeating Pattern Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<int>
	{
	}
}
