// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DiscreteFilteredGenerator{Single,TGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Float Filtered Generator Provider",
		fileName = "FloatFilteredGeneratorProvider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class FloatFilteredGeneratorProvider : DiscreteFilteredGeneratorProvider<float>
	{
	}
}
