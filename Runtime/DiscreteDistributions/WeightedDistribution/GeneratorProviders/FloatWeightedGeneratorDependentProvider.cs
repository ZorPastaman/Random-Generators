// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeightedDistributionsFolder + "Float Weighted Generator Dependent Provider",
		fileName = "Float Weighted Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class FloatWeightedGeneratorDependentProvider : WeightedGeneratorDependentProvider<float>
	{
	}
}
