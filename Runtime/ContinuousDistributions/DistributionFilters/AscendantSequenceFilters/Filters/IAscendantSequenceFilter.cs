// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="AscendantSequenceFiltering"/>.
	/// </summary>
	public interface IAscendantSequenceFilter : IContinuousFilter
	{
		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		byte ascendantSequenceLength { get; }
	}
}
