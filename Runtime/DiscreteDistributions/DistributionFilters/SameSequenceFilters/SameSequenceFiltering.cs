// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class SameSequenceFiltering
	{
		public const byte DefaultAllowedSequenceLength = 4;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is the same and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="allowedSameSequenceLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte allowedSameSequenceLength) where T : IEquatable<T>
		{
			bool same = true;

			for (int i = sequenceLength - allowedSameSequenceLength; same & i < sequenceLength; ++i)
			{
				same = sequence[i].Equals(newValue);
			}

			return same;
		}
	}
}
