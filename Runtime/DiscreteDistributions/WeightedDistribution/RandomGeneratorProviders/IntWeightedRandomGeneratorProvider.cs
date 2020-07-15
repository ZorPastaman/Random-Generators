// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGenerator{Int32}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder + "Int Weighted Random Generator Provider",
		fileName = "Int Weighted RandomGenerator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IntWeightedRandomGeneratorProvider : WeightedRandomGeneratorProvider<int>
	{
	}
}
