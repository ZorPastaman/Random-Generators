// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGenerator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder + "Float Weighted Generator Provider",
		fileName = "Float Weighted Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class FloatWeightedGeneratorProvider : WeightedGeneratorProvider<float>
	{
	}
}
