// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class FrequentValueFiltering
	{
		public const byte DefaultControlledSequenceLength = 9;
		public const byte DefaultAllowedRepeats = 2;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> is contained in the sequence <paramref name="sequence"/>
		/// more than allowed times <paramref name="allowedRepeats"/> and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="allowedRepeats"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static unsafe bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte controlledSequenceLength, byte allowedRepeats) where T : IEquatable<T>
		{
			byte repeats = 0;

			for (int i = sequenceLength - controlledSequenceLength; i < sequenceLength; ++i)
			{
				bool equal = sequence[i].Equals(newValue);
				repeats += *(byte*)&equal;
			}

			return repeats > allowedRepeats;
		}
	}
}
