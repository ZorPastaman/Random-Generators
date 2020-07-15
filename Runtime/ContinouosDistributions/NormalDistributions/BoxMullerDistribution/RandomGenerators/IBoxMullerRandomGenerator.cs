// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// A <see cref="IContinuousRandomGenerator"/> using functions from <see cref="BoxMullerDistribution"/>.
	/// </summary>
	public interface IBoxMullerRandomGenerator : IContinuousRandomGenerator
	{
		float mean { get; }
		float deviation { get; }
	}
}
