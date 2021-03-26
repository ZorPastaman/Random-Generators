// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="PoissonDistribution"/>.
	/// </summary>
	public interface IPoissonGenerator : IDiscreteGenerator<int>
	{
		float lambda { get; }
	}
}
