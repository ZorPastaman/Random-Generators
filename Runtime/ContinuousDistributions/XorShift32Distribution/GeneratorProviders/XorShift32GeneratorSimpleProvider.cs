// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift32Generator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Simple Provider",
		fileName = "XorShift32GeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private XorShift32Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift32Generator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32Generator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift32Generator;

		/// <summary>
		/// Creates a new <see cref="XorShift32Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift32Generator xorShift32Generator
		{
			[Pure]
			get => new XorShift32Generator();
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32Generator"/>.
		/// </summary>
		[NotNull]
		public XorShift32Generator sharedXorShift32Generator
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
