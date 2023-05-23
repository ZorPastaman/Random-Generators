// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="InRangeFiltering"/>.
	/// </summary>
	public interface IInRangeFilter : IContinuousFilter
	{
		float min { get; }
		float max { get; }

		/// <summary>
		/// Allowed in range sequence length.
		/// </summary>
		byte inRangeSequenceLength { get; }
	}
}
