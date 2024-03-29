// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Int Frequent Value Filter Provider",
		fileName = "IntFrequentValueFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntFrequentValueFilterProvider : FrequentValueFilterProvider<int>
	{
	}
}
