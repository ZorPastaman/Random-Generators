// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceDiscreteFiltersFolder +
			"Int Ascendant Sequence Filter Provider",
		fileName = "Int Ascendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
		)]
	public sealed class IntAscendantSequenceFilterProvider : AscendantSequenceFilterProvider<int>
	{
	}
}
