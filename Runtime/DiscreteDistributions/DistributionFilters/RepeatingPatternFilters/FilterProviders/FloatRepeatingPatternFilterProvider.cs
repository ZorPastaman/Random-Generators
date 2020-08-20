// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder + 
			"Float Repeating Pattern Filter Provider",
		fileName = "Float Repeating Pattern Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<float>
	{
	}
}
