// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public abstract class FilterProvider<T> : FilterProvider_Base
	{
		[NotNull]
		public abstract IFilter<T> filter { get; }

		[NotNull]
		public abstract IFilter<T> sharedFilter { get; }
	}
}
