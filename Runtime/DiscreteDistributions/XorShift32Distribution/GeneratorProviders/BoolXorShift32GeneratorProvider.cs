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
	/// Provides <see cref="BoolXorShift32Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32DiscreteDistributionFolder + "Bool XorShift32 Generator Provider",
		fileName = "Bool XorShift32 Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXorShift32GeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialState = XorShift32Defaults.InitialState;
#pragma warning restore CS0649

		[NonSerialized] private BoolXorShift32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift32Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolXorShift32Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift32Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
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
		/// Creates a new <see cref="BoolXorShift32Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolXorShift32Generator xorShift32Generator
		{
			[Pure]
			get => new BoolXorShift32Generator(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift32Generator"/>.
		/// </summary>
		[NotNull]
		public BoolXorShift32Generator sharedXorShift32Generator
		{
			[Pure]
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
