// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public interface ISameSequenceFilter<in T> : IDiscreteFilter<T>
	{
		byte allowedSameSequenceLength { get; }
	}
}
