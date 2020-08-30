// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class ContinuousFilterExtensions
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
		public static bool NeedRegenerate([NotNull] this IContinuousFilter[] filters, [NotNull] float[] sequence,
			float newValue, byte sequenceLength)
		{
			bool needRegenerate = false;

			for (int i = 0, count = filters.Length; !needRegenerate & i < count; ++i)
			{
				IContinuousFilter filter = filters[i];
				needRegenerate = filter.requiredSequenceLength <= sequenceLength &&
					filter.NeedRegenerate(sequence, newValue, sequenceLength);
			}

			return needRegenerate;
		}
	}
}
