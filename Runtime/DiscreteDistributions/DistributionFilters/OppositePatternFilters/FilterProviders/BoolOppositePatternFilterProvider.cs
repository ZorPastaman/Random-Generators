// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="OppositePatternFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.OppositePatterDiscreteFiltersFolder + "Bool Opposite Pattern Filter",
		fileName = "BoolOppositePatternFilter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolOppositePatternFilterProvider : OppositePatternFilterProvider<bool>
	{
	}
}
