// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift32GeneratorRangedInclusive"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Ranged Inclusive Simple Provider",
		fileName = "XorShift32GeneratorRangedInclusiveSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorRangedInclusiveSimpleProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min = XorShift32Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift32Defaults.DefaultMax;

		private XorShift32GeneratorRangedInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorRangedInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorRangedInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift32Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorRangedInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorRangedInclusive xorShift32Generator
		{
			[Pure]
			get => new XorShift32GeneratorRangedInclusive(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorRangedInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorRangedInclusive sharedXorShift32Generator
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
