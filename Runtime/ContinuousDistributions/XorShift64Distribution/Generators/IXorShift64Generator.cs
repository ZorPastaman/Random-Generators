// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="XorShift64"/>.
	/// </summary>
	public interface IXorShift64Generator : IContinuousGenerator
	{
		XorShift64 randomEngine { get; }
		float min { get; }
		float max { get; }
	}
}
