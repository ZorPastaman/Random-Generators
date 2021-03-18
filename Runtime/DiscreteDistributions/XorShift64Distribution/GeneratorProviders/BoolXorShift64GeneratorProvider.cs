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
	/// Provides <see cref="BoolXorShift64Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64DiscreteDistributionFolder + "Bool XorShift64 Generator Provider",
		fileName = "BoolXorShift64GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXorShift64GeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1L, long.MaxValue)]
		private ulong m_InitialState = XorShift64Defaults.InitialState;
#pragma warning restore CS0649

		[NonSerialized] private BoolXorShift64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift64Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolXorShift64Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift64Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
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
		/// Creates a new <see cref="BoolXorShift64Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolXorShift64Generator xorShift64Generator
		{
			[Pure]
			get => new BoolXorShift64Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift64Generator"/>.
		/// </summary>
		[NotNull]
		public BoolXorShift64Generator sharedXorShift64Generator
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
