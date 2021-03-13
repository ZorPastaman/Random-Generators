// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="PairFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PairDiscreteFiltersFolder + "Bool Pair Filter Provider",
		fileName = "Bool Pair Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
		)]
	public sealed class BoolPairFilterProvider : PairFilterProvider<bool>
	{
	}
}
