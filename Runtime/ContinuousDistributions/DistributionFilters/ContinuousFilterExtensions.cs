// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class ContinuousFilterExtensions
	{
		[Pure]
		public static bool NeedRegenerate([NotNull] this IContinuousFilter[] filters, [NotNull] float[] sequence,
			float newValue, byte sequenceLength)
		{
			bool needRegenerate = false;

			for (int i = 0, count = filters.Length; !needRegenerate && i < count; ++i)
			{
				IContinuousFilter filter = filters[i];
				needRegenerate = filter.requiredSequenceLength <= sequenceLength &&
					filter.NeedRegenerate(sequence, newValue, sequenceLength);
			}

			return needRegenerate;
		}
	}
}
