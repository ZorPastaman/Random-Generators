// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// A <see cref="IContinuousGenerator"/> using functions from <see cref="GammaDistribution"/>.
	/// </summary>
	public interface IGammaGenerator : IContinuousGenerator
	{
		/// <summary>
		/// Shape.
		/// </summary>
		float alpha { get; }

		/// <summary>
		/// Scale.
		/// </summary>
		float beta { get; }

		float startPoint { get; }
	}
}
