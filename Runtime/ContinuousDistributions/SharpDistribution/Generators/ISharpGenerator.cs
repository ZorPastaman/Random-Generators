// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="System.Random"/>.
	/// </summary>
	public interface ISharpGenerator : IContinuousGenerator
	{
		[NotNull]
		Random random { get; }
		float min { get; }
		float max { get; }
	}
}
