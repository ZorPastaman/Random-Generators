// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Simple Provider",
		fileName = "Box-Muller Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoxMullerGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private BoxMullerGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = new BoxMullerGeneratorSimple();
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorSimple boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorSimple sharedBoxMullerGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = new BoxMullerGeneratorSimple();
				}

				return m_sharedGenerator;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
