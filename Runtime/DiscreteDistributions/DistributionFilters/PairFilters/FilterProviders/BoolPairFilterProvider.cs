// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PairDiscreteFiltersFolder + "Bool Pair Filter Provider",
		fileName = "Bool Pair Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
		)]
	public sealed class BoolPairFilterProvider : PairFilterProvider<bool>
	{
	}
}
