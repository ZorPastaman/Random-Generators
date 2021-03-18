// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class NotInRangeFiltering
	{
		public const float DefaultMin = -1f;
		public const float DefaultMax = 1f;
		public const byte DefaultNotInRangeSequenceLength = 3;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is not in range between the minimum <paramref name="min"/> and maximum <paramref name="max"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="notInRangeSequenceLength">Allowed not in range sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float min, float max,
			byte sequenceLength, byte notInRangeSequenceLength)
		{
			bool inWrongRange = true;

			for (int i = sequenceLength - notInRangeSequenceLength; inWrongRange & i < sequenceLength; ++i)
			{
				float value = sequence[i];
				inWrongRange = min > value | max < value;
			}

			return inWrongRange & (min > newValue | max < newValue);
		}
	}
}
