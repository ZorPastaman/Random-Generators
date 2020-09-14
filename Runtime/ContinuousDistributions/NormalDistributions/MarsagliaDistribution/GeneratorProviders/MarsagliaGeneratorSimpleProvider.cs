// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Generator Simple Provider",
		fileName = "Marsaglia Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class MarsagliaGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private MarsagliaGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="MarsagliaGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new MarsagliaGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="MarsagliaGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorSimple marsagliaGenerator
		{
			[Pure]
			get => new MarsagliaGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorSimple sharedMarsagliaGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
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