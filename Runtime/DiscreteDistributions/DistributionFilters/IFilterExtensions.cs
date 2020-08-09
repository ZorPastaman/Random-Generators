// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class FilterExtensions
	{
		public static bool NeedRegenerate<T>([NotNull] this IFilter<T>[] filters, [NotNull] T[] sequence,
			[NotNull] T newValue, byte sequenceLength)
		{
			bool needRegenerate = false;

			for (int i = 0, count = filters.Length; !needRegenerate && i < count; ++i)
			{
				needRegenerate = filters[i].NeedRegenerate(sequence, newValue, sequenceLength);
			}

			return needRegenerate;
		}
	}
}
