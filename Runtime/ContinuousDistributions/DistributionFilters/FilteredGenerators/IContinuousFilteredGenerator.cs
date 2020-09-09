// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IContinuousFilteredGenerator<out T> : IContinuousGenerator where T : IContinuousGenerator
	{
		T filteredGenerator { get; }

		/// <summary>
		/// How many filters are used by this generator.
		/// </summary>
		int filtersCount { get; }

		/// <summary>
		/// Returns a <see cref="IContinuousFilter"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="IContinuousFilter"/> at the index <paramref name="index"/>.</returns>
		IContinuousFilter GetFilter(int index);
	}
}
