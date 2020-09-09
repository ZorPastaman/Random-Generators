// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="ExtremeFiltering"/>.
	/// </summary>
	public interface IExtremeFilter : IContinuousFilter
	{
		float expectedMin { get; }
		float expectedMax { get; }

		/// <summary>
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </summary>
		float range { get; }

		/// <summary>
		/// Allowed extreme sequence length.
		/// </summary>
		byte extremeSequenceLength { get; }
	}
}
