// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class LittleDifferenceFiltering
	{
		public const float DefaultRequiredDifference = 0.02f;
		public const byte DefaultLittleDifferenceSequenceLength = 1;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where consecutive elements differ by less than the required difference <paramref name="requiredDifference"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="requiredDifference"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="littleDifferenceSequenceLength">Allowed little difference sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float requiredDifference,
			byte sequenceLength, byte littleDifferenceSequenceLength)
		{
			bool littleDifference = true;

			for (int i = sequenceLength - littleDifferenceSequenceLength + 1;
				littleDifference & i < sequenceLength;
				++i)
			{
				littleDifference = Mathf.Abs(sequence[i] - sequence[i - 1]) < requiredDifference;
			}

			return littleDifference & Mathf.Abs(newValue - sequence[sequenceLength - 1]) < requiredDifference;
		}
	}
}
