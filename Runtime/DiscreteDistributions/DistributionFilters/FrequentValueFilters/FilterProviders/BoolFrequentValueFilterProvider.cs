// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Bool Frequent Value Filter Provider",
		fileName = "BoolFrequentValueFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolFrequentValueFilterProvider : FrequentValueFilterProvider<bool>
	{
	}
}
