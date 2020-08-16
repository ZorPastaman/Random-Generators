// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Float Same Sequence Discrete Filter",
		fileName = "Float Same Sequence Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatSameSequenceFilterProvider : SameSequenceFilterProvider<float>
	{
	}
}
