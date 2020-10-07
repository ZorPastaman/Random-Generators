// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="BinomialDistribution"/>.
	/// </summary>
	public interface IBinomialGenerator : IDiscreteGenerator<int>
	{
		int startPoint { get; }

		/// <summary>
		/// True threshold in range [0, 1).
		/// </summary>
		float probability { get; }

		byte upperBound { get; }
	}
}
