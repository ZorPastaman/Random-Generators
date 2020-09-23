// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="MarsagliaDistribution"/>.
	/// </summary>
	public interface IMarsagliaGenerator : IContinuousGenerator
	{
		float mean { get; }
		float deviation { get; }
	}
}
