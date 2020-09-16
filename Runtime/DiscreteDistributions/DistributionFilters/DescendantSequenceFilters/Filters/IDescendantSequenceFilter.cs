// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="DescendantSequenceFiltering"/>.
	/// </summary>
	public interface IDescendantSequenceFilter<in T> : IDiscreteFilter<T>
	{
		/// <summary>
		/// Allowed descendant sequence length.
		/// </summary>
		byte descendantSequenceLength { get; }
	}
}
