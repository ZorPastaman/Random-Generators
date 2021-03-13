// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="RepeatingPatternFiltering"/>.
	/// </summary>
	public interface IRepeatingPatternFilter<in T> : IDiscreteFilter<T>
	{
		byte controlledSequenceLength { get; }
		byte patternLength { get; }
	}
}
