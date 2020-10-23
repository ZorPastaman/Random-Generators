// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	public interface IXorShift32Generator : IContinuousGenerator
	{
		XorShift32 randomEngine { get; }
		float min { get; }
		float max { get; }
	}
}
