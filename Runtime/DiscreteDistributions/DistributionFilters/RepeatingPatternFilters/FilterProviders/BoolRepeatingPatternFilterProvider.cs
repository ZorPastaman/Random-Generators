// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="RepeatingPatternFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder +
			"Bool Repeating Pattern Filter Provider",
		fileName = "BoolRepeatingPatternFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<bool>
	{
	}
}
