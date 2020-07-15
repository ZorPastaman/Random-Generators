// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// A <see cref="IContinuousRandomGenerator"/> using functions from <see cref="BatesDistribution"/>.
	/// </summary>
	public interface IBatesRandomGenerator : IContinuousRandomGenerator
	{
		float mean { get; }
		float deviation { get; }

		/// <summary>
		/// How many independent and identically distributed random variables are generated.
		/// </summary>
		byte iids { get; }
	}
}
