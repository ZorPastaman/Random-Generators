// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="BatesDistribution"/>.
	/// </summary>
	public interface IBatesGenerator : IContinuousGenerator
	{
		/// <summary>
		/// How many independent and identically distributed random values are generated.
		/// </summary>
		byte iids { get; }
	}
}
