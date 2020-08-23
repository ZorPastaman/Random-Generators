// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[Serializable]
	public sealed class LittleDifferenceFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_RequiredDifference = 0.02f;
		[SerializeField] private byte m_ControlledSequenceLength = 2;
#pragma warning restore CS0649

		public LittleDifferenceFilter()
		{
		}

		public LittleDifferenceFilter(float requiredDifference, byte controlledSequenceLength)
		{
			m_RequiredDifference = requiredDifference;
			m_ControlledSequenceLength = controlledSequenceLength;
		}

		public LittleDifferenceFilter([NotNull] LittleDifferenceFilter other)
		{
			m_RequiredDifference = other.m_RequiredDifference;
			m_ControlledSequenceLength = other.m_ControlledSequenceLength;
		}

		public float requiredDifference
		{
			[Pure]
			get => m_RequiredDifference;
			set => m_RequiredDifference = value;
		}

		public byte controlledSequenceLength
		{
			[Pure]
			get => m_ControlledSequenceLength;
			set => m_ControlledSequenceLength = value;
		}

		public byte requiredSequenceLength
		{
			[Pure]
			get => m_ControlledSequenceLength;
		}

		[Pure]
		public bool NeedRegenerate(float[] sequence, float newValue, byte sequenceLength)
		{
			bool littleDifferenceSequence = true;

			for (int i = sequenceLength - m_ControlledSequenceLength + 1;
				littleDifferenceSequence && i < sequenceLength;
				++i)
			{
				littleDifferenceSequence = Mathf.Abs(sequence[i] - sequence[i - 1]) < m_RequiredDifference;
			}

			return littleDifferenceSequence &&
				Mathf.Abs(newValue - sequence[sequenceLength - 1]) < m_RequiredDifference;
		}
	}
}
