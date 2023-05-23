// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="GreaterFiltering"/>.
	/// </summary>
	public interface IGreaterFilter : IContinuousFilter
	{
		float referenceValue { get; }

		/// <summary>
		/// Allowed greater sequence length.
		/// </summary>
		byte greaterSequenceLength { get; }
	}
}
