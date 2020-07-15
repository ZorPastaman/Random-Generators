// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Continuous random generator.
	/// </summary>
	public interface IContinuousRandomGenerator
	{
		/// <summary>
		/// Generates a random value and returns it.
		/// </summary>
		/// <returns>Generated value.</returns>
		float Generate();
	}
}
