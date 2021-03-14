// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="XorShift128"/>.
	/// </summary>
	public interface IXorShift128Generator<out T> : IDiscreteGenerator<T>
	{
		XorShift128 randomEngine { get; }
		T min { get; }
		T max { get; }
	}
}
