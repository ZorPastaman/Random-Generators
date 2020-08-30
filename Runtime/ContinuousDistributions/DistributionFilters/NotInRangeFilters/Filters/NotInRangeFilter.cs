// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[Serializable]
	public sealed class NotInRangeFilter : IContinuousFilter
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = -1f;
		[SerializeField] private float m_Max = 1f;
		[SerializeField] private byte m_ControlledSequenceLength = 4;
#pragma warning restore CS0649

		public NotInRangeFilter()
		{
		}

		public NotInRangeFilter(float min, float max, byte controlledSequenceLength)
		{
			m_Min = min;
			m_Max = max;
			m_ControlledSequenceLength = controlledSequenceLength;
		}

		public NotInRangeFilter([NotNull] NotInRangeFilter other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
			m_ControlledSequenceLength = other.m_ControlledSequenceLength;
		}

		public float min
		{
			[Pure]
			get => m_Min;
			set => m_Min = value;
		}

		public float max
		{
			[Pure]
			get => m_Max;
			set => m_Max = value;
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
			bool inWrongRange = true;

			for (int i = sequenceLength - m_ControlledSequenceLength; inWrongRange & i < sequenceLength; ++i)
			{
				float value = sequence[i];
				inWrongRange = m_Min > value | m_Max < value;
			}

			return inWrongRange & (m_Min > newValue | m_Max < newValue);
		}
	}
}
