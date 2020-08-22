// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public interface IContinuousFilter
	{
		byte requiredSequenceLength { get; }

		bool NeedRegenerate([NotNull] float[] sequence, float newValue, byte sequenceLength);
	}
}
