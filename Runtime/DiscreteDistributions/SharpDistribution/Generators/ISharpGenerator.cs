// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// A <see cref="IDiscreteGenerator{T}"/> using functions from <see cref="System.Random"/>.
	/// </summary>
	public interface ISharpGenerator<out T> : IDiscreteGenerator<T>
	{
		[NotNull]
		Random random { get; }
		T min { get; }
		T max { get; }
	}
}
