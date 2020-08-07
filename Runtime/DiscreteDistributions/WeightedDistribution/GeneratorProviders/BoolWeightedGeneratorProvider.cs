// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGenerator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionFolder + "Bool Weighted Generator Provider",
		fileName = "Bool Weighted Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolWeightedGeneratorProvider : WeightedGeneratorProvider<bool>
	{
	}
}
