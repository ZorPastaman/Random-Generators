// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class RepeatingPatternFiltering
	{
		public const byte DefaultControlledSequenceLength = 9;
		public const byte DefaultPatternLength = 2;

		/// <summary>
		/// Checks if the new value <paramref name="newValue"/> forms a pattern the same to a pattern
		/// some elements before and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="controlledSequenceLength"></param>
		/// <param name="patternLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte controlledSequenceLength, byte patternLength) where T : IEquatable<T>
		{
			int checkStartIndex = sequenceLength - patternLength + 1;
			int samePatternIndex = sequenceLength - controlledSequenceLength;
			bool foundPattern = false;

			for (int stopIndex = checkStartIndex - patternLength + 1;
				!foundPattern & samePatternIndex < stopIndex;
				++samePatternIndex)
			{
				foundPattern = sequence[samePatternIndex + patternLength - 1].Equals(newValue) &&
					IsPatternSame(sequence, samePatternIndex, checkStartIndex, sequenceLength);
			}

			return foundPattern;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static bool IsPatternSame<T>([NotNull] T[] sequence, int leftPatternIndex, int rightPatternIndex,
			int sequenceLength) where T : IEquatable<T>
		{
			bool isSame = true;

			for (; isSame & rightPatternIndex < sequenceLength; ++leftPatternIndex, ++rightPatternIndex)
			{
				isSame = sequence[leftPatternIndex].Equals(sequence[rightPatternIndex]);
			}

			return isSame;
		}
	}
}
