// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Continuous random generator.
	/// </summary>
	public interface IContinuousGenerator
	{
		/// <summary>
		/// Generates a random value and returns it.
		/// </summary>
		/// <returns>Generated value.</returns>
		float Generate();
	}
}
