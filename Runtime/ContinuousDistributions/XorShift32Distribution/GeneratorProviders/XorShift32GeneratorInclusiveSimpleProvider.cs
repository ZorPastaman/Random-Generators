// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift32GeneratorInclusive"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift32ContinuousDistributionFolder +
			"XorShift32 Generator Inclusive Simple Provider",
		fileName = "XorShift32GeneratorInclusiveSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift32GeneratorInclusiveSimpleProvider : ContinuousGeneratorProvider
	{
		private XorShift32GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift32GeneratorInclusive;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift32GeneratorInclusive;

		/// <summary>
		/// Creates a new <see cref="XorShift32GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorInclusive xorShift32GeneratorInclusive
		{
			[Pure]
			get => new XorShift32GeneratorInclusive();
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift32GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift32GeneratorInclusive sharedXorShift32GeneratorInclusive
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift32GeneratorInclusive;
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
