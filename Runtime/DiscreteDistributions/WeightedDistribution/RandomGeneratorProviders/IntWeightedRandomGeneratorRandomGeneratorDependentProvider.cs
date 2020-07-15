// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGeneratorRandomGeneratorDependent{Int,TRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder +
			"Int Weighted Random Generator Random Generator Dependent Provider",
		fileName = "Int Weighted Random Generator Random Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IntWeightedRandomGeneratorRandomGeneratorDependentProvider :
		WeightedRandomGeneratorRandomGeneratorDependentProvider<int>
	{
	}
}
