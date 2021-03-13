// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// A filter that uses functions from <see cref="CloseFiltering"/>.
	/// </summary>
	public interface ICloseFilter : IContinuousFilter
	{
		float referenceValue { get; }

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		float range { get; }

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		byte closeSequenceLength { get; }
	}
}
