// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// A modificator that adds <see cref="item"/> to a result of a continuous generator.
	/// </summary>
	public interface IAddModificator : IContinuousGenerator
	{
		float item { get; }
	}
}
