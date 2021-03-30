// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift64GeneratorRanged"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64ContinuousDistributionFolder +
			"XorShift64 Generator Ranged Simple Provider",
		fileName = "XorShift64GeneratorRangedSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift64GeneratorRangedSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = XorShift64Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift64Defaults.DefaultMax;
#pragma warning restore CS0649

		private XorShift64GeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorRanged"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift64Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorRanged xorShift64Generator
		{
			[Pure]
			get => new XorShift64GeneratorRanged(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorRanged"/>.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorRanged sharedXorShift64Generator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift64Generator;
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
