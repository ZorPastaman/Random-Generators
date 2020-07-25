// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGenerator{Boolean}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder + "Bool Weighted Random Generator Provider",
		fileName = "Bool Weighted RandomGenerator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoolWeightedRandomGeneratorProvider : WeightedRandomGeneratorProvider<bool>
	{
	}
}
