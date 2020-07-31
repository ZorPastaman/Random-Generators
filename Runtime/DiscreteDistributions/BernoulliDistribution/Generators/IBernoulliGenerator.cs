// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="BernoulliDistribution"/>.
	/// </summary>
	public interface IBernoulliGenerator : IDiscreteGenerator<bool>
	{
		/// <summary>
		/// True threshold in range [0, 1].
		/// </summary>
		float p { get; }
	}
}
