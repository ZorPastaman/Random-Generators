// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGenerator{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder + "Float Weighted Random Generator Provider",
		fileName = "Float Weighted RandomGenerator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class FloatWeightedRandomGeneratorProvider : WeightedRandomGeneratorProvider<float>
	{
	}
}
