// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift32GeneratorRanged"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Ranged Provider",
		fileName = "XorShift32GeneratorRangedProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorRangedProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialState = XorShift32Defaults.InitialState;
		[SerializeField] private float m_Min = XorShift32Defaults.DefaultMin;
		[SerializeField] private float m_Max = XorShift32Defaults.DefaultMax;
#pragma warning restore CS0649

		private XorShift32GeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorRanged"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift32Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorRanged xorShift32Generator
		{
			[Pure]
			get => new XorShift32GeneratorRanged(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorRanged"/>.
		/// </summary>
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

		/// <summary>
		/// Initial state of <see cref="XorShift32"/>. Must be non-zero.
		/// </summary>
		public uint initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InitialState;
			set
			{
				if (m_InitialState == value)
				{
					return;
				}

				m_InitialState = value;
				m_sharedGenerator = null;
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
