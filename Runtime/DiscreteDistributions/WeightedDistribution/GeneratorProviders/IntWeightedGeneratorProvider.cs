// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGenerator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionFolder + "Int Weighted Generator Provider",
		fileName = "IntWeightedGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntWeightedGeneratorProvider : WeightedGeneratorProvider<int>
	{
	}
}
