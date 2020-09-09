// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="NotInRangeFiltering"/>.
	/// </summary>
	public interface INotInRangeFilter : IContinuousFilter
	{
		float min { get; }
		float max { get; }

		/// <summary>
		/// Allowed not in range sequence length.
		/// </summary>
		byte notInRangeSequenceLength { get; }
	}
}
