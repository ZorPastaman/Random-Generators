// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="PairFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PairDiscreteFiltersFolder + "Float Pair Filter Provider",
		fileName = "Float Pair Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatPairFilterProvider : PairFilterProvider<float>
	{
	}
}
