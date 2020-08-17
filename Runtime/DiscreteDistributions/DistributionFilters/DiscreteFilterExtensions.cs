// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class DiscreteFilterExtensions
	{
		public static bool NeedRegenerate<T>([NotNull] this IDisceteFilter<T>[] filters, [NotNull] T[] sequence,
			[NotNull] T newValue, byte sequenceLength)
		{
			bool needRegenerate = false;

			for (int i = 0, count = filters.Length; !needRegenerate && i < count; ++i)
			{
				IDisceteFilter<T> filter = filters[i];

				if (filter.requiredSequenceLength <= sequenceLength)
				{
					needRegenerate = filter.NeedRegenerate(sequence, newValue, sequenceLength);
				}
			}

			return needRegenerate;
		}
	}
}
