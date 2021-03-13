// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class AscendantSequenceFiltering
	{
		public const byte DefaultAscendantSequenceLength = 3;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the ascendant sequence <paramref name="sequence"/>
		/// and it needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="ascendantSequenceLength">Allowed ascendant sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte ascendantSequenceLength) where T : IComparable<T>
		{
			bool ascending = true;

			for (int i = sequenceLength - ascendantSequenceLength + 1; ascending & i < sequenceLength; ++i)
			{
				ascending = sequence[i - 1].CompareTo(sequence[i]) < 0;
			}

			return ascending & sequence[sequenceLength - 1].CompareTo(newValue) < 0;
		}
	}
}
