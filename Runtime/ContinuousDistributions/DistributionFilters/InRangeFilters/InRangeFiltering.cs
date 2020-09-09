// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class InRangeFiltering
	{
		public const float DefaultMin = -1f;
		public const float DefaultMax = 1f;
		public const byte DefaultInRangeSequenceLength = 3;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the in range sequence <paramref name="sequence"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="inRangeSequenceLength">Allowed in range sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float min, float max,
			byte sequenceLength, byte inRangeSequenceLength)
		{
			bool inRange = true;

			for (int i = sequenceLength - inRangeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				float value = sequence[i];
				inRange = min <= value & max >= value;
			}

			return inRange & min <= newValue & max >= newValue;
		}
	}
}
