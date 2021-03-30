// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift64Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64ContinuousDistributionFolder +
			"XorShift64 Generator Simple Provider",
		fileName = "XorShift64GeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift64GeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private XorShift64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift64Generator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64Generator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift64Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift64Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift64Generator xorShift64Generator
		{
			[Pure]
			get => new XorShift64Generator();
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64Generator"/>.
		/// </summary>
		[NotNull]
		public XorShift64Generator sharedXorShift64Generator
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
