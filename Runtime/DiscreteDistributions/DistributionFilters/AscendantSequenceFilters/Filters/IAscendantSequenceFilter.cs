// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="AscendantSequenceFiltering"/>.
	/// </summary>
	public interface IAscendantSequenceFilter<in T> : IDiscreteFilter<T>
	{
		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		byte ascendantSequenceLength { get; }
	}
}
