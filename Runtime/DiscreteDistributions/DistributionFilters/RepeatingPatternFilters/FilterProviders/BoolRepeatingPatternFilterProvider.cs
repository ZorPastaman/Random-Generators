// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder +
			"Bool Repeating Pattern Filter Provider",
		fileName = "Bool Repeating Pattern Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<bool>
	{
	}
}