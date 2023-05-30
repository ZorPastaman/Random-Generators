// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift64GeneratorInclusive"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64ContinuousDistributionFolder +
			"XorShift64 Generator Inclusive Simple Provider",
		fileName = "XorShift64GeneratorInclusiveSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift64GeneratorInclusiveSimpleProvider : ContinuousGeneratorProvider
	{
		private XorShift64GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift64GeneratorInclusive;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift64GeneratorInclusive;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorInclusive xorShift64GeneratorInclusive
		{
			[Pure]
			get => new XorShift64GeneratorInclusive();
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorInclusive sharedXorShift64GeneratorInclusive
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift64GeneratorInclusive;
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
