// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class OppositePatternFiltering
	{
		public const byte DefaultPatterLength = 3;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> forms a pattern opposite to a previous pattern
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="patternLength"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		/// <remarks>
		/// Type <typeparamref name="T"/> must take only two values like <see cref="bool"/>.
		/// </remarks>
		[Pure]
		public static bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte patternLength) where T : IEquatable<T>
		{
			bool oppositePattern = true;

			for (int i = sequenceLength - patternLength * 2 + 1, j = sequenceLength - patternLength + 1;
				oppositePattern & j < sequenceLength;
				++i, ++j)
			{
				oppositePattern = !sequence[i].Equals(sequence[j]);
			}

			return oppositePattern & !sequence[sequenceLength - patternLength].Equals(newValue);
		}
	}
}
