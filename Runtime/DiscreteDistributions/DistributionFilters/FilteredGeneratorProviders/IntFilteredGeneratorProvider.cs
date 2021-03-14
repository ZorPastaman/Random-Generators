// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DiscreteFilteredGenerator{Int32,TGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteFilteredGeneratorsFolder + "Int Filtered Generator Provider",
		fileName = "IntFilteredGeneratorProvider",
		order = CreateAssetMenuConstants.FilteredGeneratorOrder
	)]
	public sealed class IntFilteredGeneratorProvider : DiscreteFilteredGeneratorProvider<int>
	{
	}
}
