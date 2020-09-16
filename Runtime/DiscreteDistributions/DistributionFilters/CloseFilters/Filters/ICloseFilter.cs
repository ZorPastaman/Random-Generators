// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// The filter recommends to regenerate a new value if it continues a sequence where every value is too close
	/// to a reference value.
	/// </summary>
	public interface ICloseFilter<T> : IDiscreteFilter<T>
	{
		T referenceValue { get; }

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		T range { get; }

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		byte closeSequenceLength { get; }
	}
}
