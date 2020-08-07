// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Simple Provider",
		fileName = "Marsaglia Random Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class MarsagliaRandomGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private MarsagliaGeneratorSimple m_MarsagliaGenerator;
#pragma warning restore CS0649

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
			[Pure]
			get => m_MarsagliaGenerator;
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
			[Pure]
			get => m_MarsagliaGenerator;
		}
	}
}
