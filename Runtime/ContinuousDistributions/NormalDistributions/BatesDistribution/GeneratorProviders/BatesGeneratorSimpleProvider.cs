// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Simple Provider",
		fileName = "Bates Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BatesGeneratorSimple m_BatesGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGeneratorSimple(m_BatesGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_BatesGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGeneratorSimple batesGenerator
		{
			[Pure]
			get => new BatesGeneratorSimple(m_BatesGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BatesGeneratorSimple sharedBatesGenerator
		{
			[Pure]
			get => m_BatesGenerator;
		}
	}
}
