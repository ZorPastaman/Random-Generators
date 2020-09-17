// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public static class CloseFiltering
	{
		public const float DefaultReferenceValue = 0f;
		public const float DefaultRange = 1f;
		public const byte DefaultCloseSequenceLength = 4;

		/// <summary>
		/// Checks if the value <paramref name="newValue"/> continues the sequence <paramref name="sequence"/>
		/// where every value is close enough to the reference value <paramref name="referenceValue"/>
		/// and needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="referenceValue"></param>
		/// <param name="range">
		/// How far from an reference value a value may be to be counted as close enough.
		/// </param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <param name="closeSequenceLength">Allowed close sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		[Pure]
		public static bool NeedRegenerate([NotNull] float[] sequence, float newValue, float referenceValue,
			float range, byte sequenceLength, byte closeSequenceLength)
		{
			bool inRange = true;

			for (int i = sequenceLength - closeSequenceLength; inRange & i < sequenceLength; ++i)
			{
				inRange = Mathf.Abs(sequence[i] - referenceValue) < range;
			}

			return inRange & Mathf.Abs(newValue - referenceValue) < range;
		}
	}
}
