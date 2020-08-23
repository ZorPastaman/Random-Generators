// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[Serializable]
	public sealed class AscendantSequenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_AscendantSequenceLength = 5;
#pragma warning restore CS0649

		public AscendantSequenceFilter()
		{
		}

		public AscendantSequenceFilter(byte ascendantSequenceLength)
		{
			m_AscendantSequenceLength = ascendantSequenceLength;
		}

		public AscendantSequenceFilter([NotNull] AscendantSequenceFilter other)
		{
			m_AscendantSequenceLength = other.m_AscendantSequenceLength;
		}

		public byte ascendantSequenceLength
		{
			[Pure]
			get => m_AscendantSequenceLength;
			set => m_AscendantSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_AscendantSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			bool notAscending = false;

			for (int i = sequenceLength - m_AscendantSequenceLength + 1; !notAscending && i < sequenceLength; ++i)
			{
				notAscending = sequence[i - 1] >= sequence[i];
			}

			return !notAscending && sequence[sequenceLength - 1] < newValue;
		}
	}
}
