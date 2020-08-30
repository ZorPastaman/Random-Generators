// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[Serializable]
	public sealed class GreaterFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Value;
		[SerializeField] private byte m_ControlledSequenceLength;
#pragma warning restore CS0649

		public GreaterFilter()
		{
		}

		public GreaterFilter(float value, byte controlledSequenceLength)
		{
			m_Value = value;
			m_ControlledSequenceLength = controlledSequenceLength;
		}

		public GreaterFilter([NotNull] GreaterFilter other)
		{
			m_Value = other.m_Value;
			m_ControlledSequenceLength = other.m_ControlledSequenceLength;
		}

		public float value
		{
			[Pure]
			get => m_Value;
			set => m_Value = value;
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
			bool greater = true;

			for (int i = sequenceLength - m_ControlledSequenceLength; greater && i < sequenceLength; ++i)
			{
				greater = sequence[i] > m_Value;
			}

			return greater && newValue > m_Value;
		}
	}
}
