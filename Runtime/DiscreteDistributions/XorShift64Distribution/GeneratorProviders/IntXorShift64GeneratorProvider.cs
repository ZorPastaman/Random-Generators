// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IntXorShift64Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64DiscreteDistributionFolder + "Int XorShift64 Generator Provider",
		fileName = "IntXorShift64GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntXorShift64GeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1L, long.MaxValue)]
		private ulong m_InitialState = XorShift64Defaults.InitialState;
		[SerializeField] private int m_Min = XorShift64Defaults.DefaultMin;
		[SerializeField] private int m_Max = XorShift64Defaults.DefaultMax;
#pragma warning restore CS0649

		private IntXorShift64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift64Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => xorShift64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift64Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedXorShift64Generator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift64Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public IntXorShift64Generator xorShift64Generator
		{
			[Pure]
			get => new IntXorShift64Generator(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift64Generator"/>.
		/// </summary>
		[NotNull]
		public IntXorShift64Generator sharedXorShift64Generator
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

		/// <summary>
		/// Initial state of <see cref="XorShift64"/>. Must be non-zero.
		/// </summary>
		public ulong initialState
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

		public int min
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

		public int max
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
