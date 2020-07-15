// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	public interface IMarsagliaRandomGenerator : IContinuousRandomGenerator
	{
		float mean { get; }
		float deviation { get; }
	}
}
