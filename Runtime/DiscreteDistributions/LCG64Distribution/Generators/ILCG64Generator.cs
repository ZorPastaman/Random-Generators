﻿// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="LCG64"/>.
	/// </summary>
	public interface ILCG64Generator<out T> : IDiscreteGenerator<T>
	{
		LCG64 randomEngine { get; }
		T min { get; }
		T max { get; }

		/// <summary>
		/// Jumps forward.
		/// </summary>
		/// <param name="steps">How many steps to jump.</param>
		void Forward(int steps);
	}
}
