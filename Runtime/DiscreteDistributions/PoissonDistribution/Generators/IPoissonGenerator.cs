// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="PoissonDistribution"/>.
	/// </summary>
	public interface IPoissonGenerator : IDiscreteGenerator<uint>
	{
		float lambda { get; }
	}
}
