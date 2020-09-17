// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="UnityEngine.Random"/>.
	/// </summary>
	public interface IUnityGenerator<out T> : IDiscreteGenerator<T>
	{
		T min { get; }
		T max { get; }
	}
}
