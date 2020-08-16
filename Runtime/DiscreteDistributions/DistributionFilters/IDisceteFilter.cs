// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public interface IDisceteFilter<in T>
	{
		byte requiredSequenceLength { get; }

		bool NeedRegenerate([NotNull] T[] sequence, [NotNull] T newValue, byte sequenceLength);
	}
}
