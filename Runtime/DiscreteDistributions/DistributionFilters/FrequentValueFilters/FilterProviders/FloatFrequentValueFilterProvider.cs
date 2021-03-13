// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.FrequentValueDiscreteFiltersFolder + "Float Frequent Value Filter Provider",
		fileName = "Float Frequent Value Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatFrequentValueFilterProvider : FrequentValueFilterProvider<float>
	{
	}
}
