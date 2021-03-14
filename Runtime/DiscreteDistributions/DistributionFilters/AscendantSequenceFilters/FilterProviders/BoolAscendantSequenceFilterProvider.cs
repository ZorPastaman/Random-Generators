// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceDiscreteFiltersFolder +
			"Bool Ascendant Sequence Filter Provider",
		fileName = "BoolAscendantSequenceFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolAscendantSequenceFilterProvider : AscendantSequenceFilterProvider<bool>
	{
	}
}
