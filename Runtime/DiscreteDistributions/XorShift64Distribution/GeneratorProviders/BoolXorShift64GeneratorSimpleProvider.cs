// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolXorShift64Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64DiscreteDistributionFolder +
			"Bool XorShift64 Generator Simple Provider",
		fileName = "Bool XorShift64 Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXorShift64GeneratorSimpleProvider : DiscreteGeneratorProvider<bool>
	{
		[NonSerialized] private BoolXorShift64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift64Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolXorShift64Generator();
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
			get => new BoolXorShift64Generator();
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift64Generator"/>.
		/// </summary>
		[NotNull]
		public BoolXorShift64Generator sharedXorShift64Generator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift64Generator;
				}

				return m_sharedGenerator;
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
