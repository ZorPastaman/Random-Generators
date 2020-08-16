// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Int Filtered Generator Provider",
		fileName = "Int Filtered Generator Provider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class IntFilteredGeneratorProvider : DiscreteFilteredGeneratorProvider<int>
	{
	}
}