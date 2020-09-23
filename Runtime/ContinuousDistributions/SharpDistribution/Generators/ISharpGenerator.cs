// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="System.Random"/>.
	/// </summary>
	public interface ISharpGenerator : IContinuousGenerator
	{
		Random random { get; }
		float min { get; }
		float max { get; }
	}
}
