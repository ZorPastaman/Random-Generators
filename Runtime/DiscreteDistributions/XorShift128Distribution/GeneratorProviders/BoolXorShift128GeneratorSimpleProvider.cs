// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BoolXorShift128Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128DiscreteDistributionFolder +
			"Bool XorShift128 Generator Simple Provider",
		fileName = "BoolXorShift128GeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoolXorShift128GeneratorSimpleProvider : DiscreteGeneratorProvider<bool>
	{
		[NonSerialized] private BoolXorShift128Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift128Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => xorShift128Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift128Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator => sharedXorShift128Generator;

		/// <summary>
		/// Creates a new <see cref="BoolXorShift128Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolXorShift128Generator xorShift128Generator
		{
			[Pure]
			get => new BoolXorShift128Generator();
		}

		/// <summary>
		/// Returns a shared <see cref="BoolXorShift128Generator"/>.
		/// </summary>
		[NotNull]
		public BoolXorShift128Generator sharedXorShift128Generator
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
