// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGenerator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionFolder + "Float Weighted Generator Provider",
		fileName = "FloatWeightedGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class FloatWeightedGeneratorProvider : WeightedGeneratorProvider<float>
	{
	}
}
