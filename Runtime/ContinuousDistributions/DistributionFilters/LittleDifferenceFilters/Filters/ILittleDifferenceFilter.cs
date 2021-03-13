// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="LittleDifferenceFiltering"/>.
	/// </summary>
	public interface ILittleDifferenceFilter : IContinuousFilter
	{
		float requiredDifference { get; }

		/// <summary>
		/// Allowed little difference sequence length.
		/// </summary>
		byte littleDifferenceSequenceLength { get; }
	}
}
