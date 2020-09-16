// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	public static class PairFiltering
	{
		public const byte DefaultsElementsBetweenPair = 1;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> is contained in the sequence <paramref name="sequence"/>
		/// <paramref name="elementsBetweenPair"/> elements before and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="elementsBetweenPair"></param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool NeedRegenerate<T>([NotNull] T[] sequence, [CanBeNull] T newValue, byte sequenceLength,
			byte elementsBetweenPair) where T : IEquatable<T>
		{
			return sequence[sequenceLength - elementsBetweenPair - 1].Equals(newValue);
		}
	}
}
