// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="SamePatternFiltering"/>.
	/// </summary>
	public interface ISamePatternFilter<in T> : IDiscreteFilter<T>
	{
		byte patternLength { get; }
	}
}
