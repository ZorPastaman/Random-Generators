// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IntXorShift128Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128DiscreteDistributionFolder +
			"Int XorShift128 Generator Simple Provider",
		fileName = "IntXorShift128GeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntXorShift128GeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Min = XorShift128Defaults.DefaultMin;
		[SerializeField] private int m_Max = XorShift128Defaults.DefaultMax;
#pragma warning restore CS0649

		[NonSerialized] private IntXorShift128Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift128Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => xorShift128Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift128Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedXorShift128Generator;

		/// <summary>
		/// Creates a new <see cref="IntXorShift128Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public IntXorShift128Generator xorShift128Generator
		{
			[Pure]
			get => new IntXorShift128Generator(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="IntXorShift128Generator"/>.
		/// </summary>
		[NotNull]
		public IntXorShift128Generator sharedXorShift128Generator
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
