// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Float Filtered Generator Provider",
		fileName = "Float Filtered Generator Provider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class FloatFilteredGeneratorProvider : DiscreteFilteredGeneratorProvider<float>
	{
	}
}