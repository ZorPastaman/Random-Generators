// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="XorShift32"/>.
	/// </summary>
	public interface IXorShift32Generator<out T> : IDiscreteGenerator<T>
	{
		XorShift32 randomEngine { get; }
		T min { get; }
		T max { get; }

		/// <summary>
		/// Jumps forward.
		/// </summary>
		/// <param name="steps">How many steps to jump.</param>
		void Forward(int steps);
	}
}
