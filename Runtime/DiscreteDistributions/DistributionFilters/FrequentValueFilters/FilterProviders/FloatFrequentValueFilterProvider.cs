// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Float Frequent Value Filter Provider",
		fileName = "FloatFrequentValueFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatFrequentValueFilterProvider : FrequentValueFilterProvider<float>
	{
	}
}
