// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="PairFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PairDiscreteFiltersFolder + "Int Pair Filter Provider",
		fileName = "IntPairFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntPairFilterProvider : PairFilterProvider<int>
	{
	}
}
