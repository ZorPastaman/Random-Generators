// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="IrwinHallDistribution"/>.
	/// </summary>
	public interface IIrwinHallGenerator : IContinuousGenerator
	{
		float startPoint { get; }

		/// <summary>
		/// How many independent and identically distributed random variables are generated.
		/// </summary>
		byte iids { get; }
	}
}
