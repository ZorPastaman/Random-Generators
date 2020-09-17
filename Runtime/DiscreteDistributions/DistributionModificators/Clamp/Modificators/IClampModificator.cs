// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	public interface IClampModificator<out T> : IDiscreteGenerator<T>
	{
		T min { get; }
		T max { get; }
	}
}
