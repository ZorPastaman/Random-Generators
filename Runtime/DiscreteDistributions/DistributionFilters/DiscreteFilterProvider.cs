// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class DiscreteFilterProvider<T> : DiscreteFilterProvider_Base
	{
		[NotNull]
		public abstract IDisceteFilter<T> filter { get; }

		[NotNull]
		public abstract IDisceteFilter<T> sharedFilter { get; }
	}
}
