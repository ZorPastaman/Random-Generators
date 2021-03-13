// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="ExponentialDistribution"/>.
	/// </summary>
	public interface IExponentialGenerator : IContinuousGenerator
	{
		float lambda { get; }
		float startPoint { get; }
	}
}
