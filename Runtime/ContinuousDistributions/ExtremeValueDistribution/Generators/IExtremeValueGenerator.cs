// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="ExtremeValueDistribution"/>.
	/// </summary>
	public interface IExtremeValueGenerator : IContinuousGenerator
	{
		public float location { get; }

		public float scale { get; }
	}
}
