// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGeneratorRandomGeneratorDependent{Boolean,TRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder +
			"Bool Weighted Random Generator Random Generator Dependent Provider",
		fileName = "Bool Weighted Random Generator Random Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoolWeightedRandomGeneratorRandomGeneratorDependentProvider :
		WeightedRandomGeneratorRandomGeneratorDependentProvider<bool>
	{
	}
}
