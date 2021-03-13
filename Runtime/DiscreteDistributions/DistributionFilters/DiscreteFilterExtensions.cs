// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class DiscreteFilterExtensions
	{
		/// <summary>
		/// Checks with the filters <paramref name="filters"/> if the generated value <paramref name="newValue"/>
		/// for the sequence <paramref name="sequence"/> needs to be regenerated.
		/// </summary>
		/// <param name="filters">Filters array.</param>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate<T>([NotNull] this IDiscreteFilter<T>[] filters, [NotNull] T[] sequence,
			[NotNull] T newValue, byte sequenceLength)
		{
			bool needRegenerate = false;

			for (int i = 0, count = filters.Length; !needRegenerate & i < count; ++i)
			{
				IDiscreteFilter<T> filter = filters[i];
				needRegenerate = filter.requiredSequenceLength <= sequenceLength &&
					filter.NeedRegenerate(sequence, newValue, sequenceLength);
			}

			return needRegenerate;
		}
	}
}
