// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="LessFiltering"/>.
	/// </summary>
	public interface ILessFilter : IContinuousFilter
	{
		float referenceValue { get; }

		/// <summary>
		/// Allowed less sequence length.
		/// </summary>
		byte lessSequenceLength { get; }
	}
}
