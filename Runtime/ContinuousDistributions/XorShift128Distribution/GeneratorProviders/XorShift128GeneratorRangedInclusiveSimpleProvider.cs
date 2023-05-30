// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift128GeneratorRangedInclusive"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128ContinuousDistributionFolder +
			"XorShift128 Generator Ranged Inclusive Simple Provider",
		fileName = "XorShift128GeneratorRangedInclusiveSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift128GeneratorRangedInclusiveSimpleProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min = XorShift128Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift128Defaults.DefaultMax;

		private XorShift128GeneratorRangedInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift128GeneratorRangedInclusive"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift128Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorRangedInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift128Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift128GeneratorRangedInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorRangedInclusive xorShift128Generator
		{
			[Pure]
			get => new XorShift128GeneratorRangedInclusive(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorRangedInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorRangedInclusive sharedXorShift128Generator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift128Generator;
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
