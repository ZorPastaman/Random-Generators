// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class ExtremeFiltering
	{
		public const float DefaultExpectedMin = -1f;
		public const float DefaultExpectedMax = 1f;
		public const float DefaultRange = 1f;
		public const byte DefaultExtremeSequenceLength = 6;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the extreme sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="expectedMin"></param>
		/// <param name="expectedMax"></param>
		/// <param name="range">
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
		/// </param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="extremeSequenceLength">Allowed extreme sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float expectedMin,
			float expectedMax, float range, byte sequenceLength, byte extremeSequenceLength)
		{
			float extreme;

			if (newValue < expectedMin + range)
			{
				extreme = expectedMin;
			}
			else if (newValue > expectedMax - range)
			{
				extreme = expectedMax;
			}
			else
			{
				return false;
			}

			bool inRange = true;

			for (int i = sequenceLength - extremeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - extreme) < range;
			}

			return inRange;
		}
	}
}
