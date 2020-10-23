// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Ranged Provider",
		fileName = "XorShift32 Generator Ranged Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorRangedProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private uint m_InitialState = XorShift32Defaults.InitialState;
		[SerializeField] private float m_Min = XorShift32Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift32Defaults.DefaultMax;
#pragma warning restore CS0649

		[NonSerialized] private XorShift32GeneratorRanged m_sharedGenerator;

		public override IContinuousGenerator generator
		{
			[Pure]
			get => new XorShift32GeneratorRanged(m_InitialState, m_Min, m_Max);
		}

		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift32Generator;
				}

				return m_sharedGenerator;
			}
		}

		[NotNull]
		public XorShift32GeneratorRanged xorShift32Generator
		{
			[Pure]
			get => new XorShift32GeneratorRanged(m_InitialState, m_Min, m_Max);
		}

		[NotNull]
		public XorShift32GeneratorRanged sharedXorShift32Generator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift32Generator;
				}

				return m_sharedGenerator;
			}
		}

		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
