// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class DescendantSequenceFiltering
	{
		public const byte DefaultDescendantSequenceLength = 4;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues
		/// the descendant sequence <paramref name="sequence"/> and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="descendantSequenceLength">Allowed descendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, byte sequenceLength,
			byte descendantSequenceLength)
		{
			bool descending = true;

			for (int i = sequenceLength - descendantSequenceLength + 1; descending & i < sequenceLength; ++i)
			{
				descending = sequence[i - 1] > sequence[i];
			}

			return descending & sequence[sequenceLength - 1] > newValue;
		}
	}
}
