// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Discrete random generator.
	/// </summary>
	public interface IDiscreteGenerator<out T>
	{
		/// <summary>
		/// Generates a random value and returns it.
		/// </summary>
		/// <returns>Generated value.</returns>
		T Generate();
	}
}
