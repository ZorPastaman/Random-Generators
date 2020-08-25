// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[Serializable]
	public sealed class DescendantSequenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_DescendantSequenceLength = 5;
#pragma warning restore CS0649

		public DescendantSequenceFilter()
		{
		}

		public DescendantSequenceFilter(byte descendantSequenceLength)
		{
			m_DescendantSequenceLength = descendantSequenceLength;
		}

		public DescendantSequenceFilter([NotNull] DescendantSequenceFilter other)
		{
			m_DescendantSequenceLength = other.m_DescendantSequenceLength;
		}

		public byte descendantSequenceLength
		{
			[Pure]
			get => m_DescendantSequenceLength;
			set => m_DescendantSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_DescendantSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			bool notDescending = false;

			for (int i = sequenceLength - m_DescendantSequenceLength + 1; !notDescending && i < sequenceLength; ++i)
			{
				notDescending = sequence[i - 1] <= sequence[i];
			}

			return !notDescending && sequence[sequenceLength - 1] > newValue;
		}
	}
}
