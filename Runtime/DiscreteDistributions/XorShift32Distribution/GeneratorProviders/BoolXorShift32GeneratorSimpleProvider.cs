// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolXorShift32Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32DiscreteDistributionFolder +
			"Bool XorShift32 Generator Simple Provider",
		fileName = "BoolXorShift32GeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXorShift32GeneratorSimpleProvider : DiscreteGeneratorProvider<bool>
	{
		[NonSerialized] private BoolXorShift32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift32Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BoolXorShift32Generator();
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
			get => new BoolXorShift32Generator();
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift32Generator"/>.
		/// </summary>
		[NotNull]
		public BoolXorShift32Generator sharedXorShift32Generator
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
