// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteRandomGenerator{T}"/> using functions from <see cref="WeightedDistribution"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public interface IWeightedRandomGenerator<out T> : IDiscreteRandomGenerator<T>
	{
		int weightsCount { get; }

		uint GetWeight(int index);

		T GetValue(int index);
	}
}
