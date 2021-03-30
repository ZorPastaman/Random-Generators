// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IntXorShift32Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32DiscreteDistributionFolder + "Int XorShift32 Generator Provider",
		fileName = "IntXorShift32GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntXorShift32GeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialState = XorShift32Defaults.InitialState;
		[SerializeField] private int m_Min = XorShift32Defaults.DefaultMin;
		[SerializeField] private int m_Max = XorShift32Defaults.DefaultMax;
#pragma warning restore CS0649

		private IntXorShift32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift32Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => xorShift32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift32Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedXorShift32Generator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift32Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public IntXorShift32Generator xorShift32Generator
		{
			[Pure]
			get => new IntXorShift32Generator(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift32Generator"/>.
		/// </summary>
		[NotNull]
		public IntXorShift32Generator sharedXorShift32Generator
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
