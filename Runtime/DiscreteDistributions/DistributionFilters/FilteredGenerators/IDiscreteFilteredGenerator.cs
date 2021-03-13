// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Random generator that takes a generated value from its depended generator filtered with its filters.
	/// </summary>
	/// <typeparam name="TValue"></typeparam>
	/// <typeparam name="TGenerator"></typeparam>
	public interface IDiscreteFilteredGenerator<TValue, out TGenerator> : IDiscreteGenerator<TValue>
		where TGenerator : IDiscreteGenerator<TValue>
	{
		TGenerator filteredGenerator { get; }

		/// <summary>
		/// <para>How many times a value may be regenerated.</para>
		/// <para>If this value is exceeded, a last generated value is returned.</para>
		/// </summary>
		byte regenerateAttempts { get; }

		/// <summary>
		/// How many filters are used by this generator.
		/// </summary>
		int filtersCount { get; }

		/// <summary>
		/// Returns a <see cref="IDiscreteFilter{T}"/> at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns><see cref="IDiscreteFilter{T}"/> at the index <paramref name="index"/>.</returns>
		IDiscreteFilter<TValue> GetFilter(int index);
	}
}
