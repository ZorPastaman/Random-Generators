// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="RepeatingPatternFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder + 
			"Int Repeating Pattern Filter Provider",
		fileName = "IntRepeatingPatternFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<int>
	{
	}
}
