// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SameSequenceFilter{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SameSequenceDiscreteFiltersFolder + "Bool Same Sequence Discrete Filter",
		fileName = "Bool Same Sequence Discrete Filter",
		order = CreateAssetMenuConstants.FilterOrder
		)]
	public sealed class BoolSameSequenceFilterProvider : SameSequenceFilterProvider<bool>
	{
	}
}
