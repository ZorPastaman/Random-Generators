// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="Xoroshiro128Plus"/>.
	/// </summary>
	public interface IXoroshiro128PlusGenerator : IContinuousGenerator
	{
		Xoroshiro128Plus randomEngine { get; }
		float min { get; }
		float max { get; }

		/// <summary>
		/// Jumps forward.
		/// </summary>
		/// <param name="steps">How many steps to jump.</param>
		void Forward(int steps);
	}
}
