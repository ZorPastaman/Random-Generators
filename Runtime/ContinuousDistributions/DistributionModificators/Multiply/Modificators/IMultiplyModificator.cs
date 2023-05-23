// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// A modificator that multiplies <see cref="multiplier"/> and a result of a continuous generator.
	/// </summary>
	public interface IMultiplyModificator : IContinuousGenerator
	{
		float multiplier { get; }
	}
}
