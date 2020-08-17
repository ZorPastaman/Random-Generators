// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceFiltersFolder + "Float Ascendant Sequence Filter Provider",
		fileName = "Float Ascendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatAscendantSequenceFilterProvider : AscendantSequenceFilterProvider<float>
	{
	}
}
