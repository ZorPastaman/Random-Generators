// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DescendantSequenceFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceDiscreteFiltersFolder +
			"Float Descendant Sequence Filter Provider",
		fileName = "FloatDescendantSequenceFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatDescendantSequenceFilterProvider : DescendantSequenceFilterProvider<float>
	{
	}
}
