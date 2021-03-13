// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="PairFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PairDiscreteFiltersFolder + "Int Pair Filter Provider",
		fileName = "Int Pair Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntPairFilterProvider : PairFilterProvider<int>
	{
	}
}
