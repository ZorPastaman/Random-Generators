// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="PairFiltering"/>.
	/// </summary>
	public interface IPairFilter<in T> : IDiscreteFilter<T>
	{
		byte elementsBetweenPair { get; }
	}
}
