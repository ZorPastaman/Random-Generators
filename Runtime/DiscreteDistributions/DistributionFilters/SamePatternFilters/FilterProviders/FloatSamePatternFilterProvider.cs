// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SamePatternDiscreteFiltersFolder + "Float Same Pattern Filter",
		fileName = "FloatSamePatternFilter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatSamePatternFilterProvider : SamePatterFilterProvider<float>
	{
	}
}
