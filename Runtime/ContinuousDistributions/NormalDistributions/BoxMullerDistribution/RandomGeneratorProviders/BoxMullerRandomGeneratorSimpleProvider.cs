// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Random Generator Simple Provider",
		fileName = "Box-Muller Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoxMullerRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
		private BoxMullerRandomGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new BoxMullerRandomGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = new BoxMullerRandomGeneratorSimple();
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerRandomGeneratorSimple boxMullerRandomGenerator
		{
			[Pure]
			get => new BoxMullerRandomGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BoxMullerRandomGeneratorSimple sharedBoxMullerRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = new BoxMullerRandomGeneratorSimple();
				}

				return m_sharedGenerator;
			}
		}
	}
}
