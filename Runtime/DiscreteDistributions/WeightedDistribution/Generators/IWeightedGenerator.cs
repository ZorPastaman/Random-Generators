// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="WeightedDistribution"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public interface IWeightedGenerator<out T> : IDiscreteGenerator<T>
	{
		int weightsCount { get; }

		uint GetWeight(int index);

		T GetValue(int index);
	}
}
