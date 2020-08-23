// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Float Frequent Value Filter Provider",
		fileName = "Float Frequent Value Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatFrequentValueFilterProvider : FrequentValueFilterProvider<float>
	{
	}
}