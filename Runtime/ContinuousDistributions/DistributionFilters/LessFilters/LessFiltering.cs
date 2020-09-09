// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class LessFiltering
	{
		public const float DefaultReferenceValue = 0f;
		public const byte DefaultLessSequenceLength = 3;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the less sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="lessSequenceLength">Allowed less sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float referenceValue,
			byte sequenceLength, byte lessSequenceLength)
		{
			bool greater = true;

			for (int i = sequenceLength - lessSequenceLength; greater & i < sequenceLength; ++i)
			{
				greater = sequence[i] < referenceValue;
			}

			return greater & newValue < referenceValue;
		}
	}
}
