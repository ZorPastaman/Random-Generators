// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// A modificator that adds <see cref="item"/> to a result of a discrete generator.
	/// </summary>
	public interface IAddModificator<out T> : IDiscreteGenerator<T>
	{
		T item { get; }
	}
}
