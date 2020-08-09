// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Bool Filtered Generator Provider",
		fileName = "Bool Filtered Generator Provider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
		)]
	public sealed class BoolFilteredGeneratorProvider : FilteredGeneratorProvider<bool>
	{
	}
}
