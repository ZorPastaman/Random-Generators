// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SameSequenceFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Float Same Sequence Filter",
		fileName = "Float Same Sequence Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatSameSequenceFilterProvider : SameSequenceFilterProvider<float>
	{
	}
}
