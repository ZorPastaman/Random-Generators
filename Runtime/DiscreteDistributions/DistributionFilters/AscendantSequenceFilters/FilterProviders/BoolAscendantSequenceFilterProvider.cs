// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceDiscreteFiltersFolder + "Bool Ascendant Sequence Filter Provider",
		fileName = "Bool Ascendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolAscendantSequenceFilterProvider : AscendantSequenceFilterProvider<bool>
	{
	}
}
