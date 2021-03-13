// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="DescendantSequenceFiltering"/>.
	/// </summary>
	public interface IDescendantSequenceFilter : IContinuousFilter
	{
		/// <summary>
		/// Allowed descendant sequence length.
		/// </summary>
		byte descendantSequenceLength { get; }
	}
}
