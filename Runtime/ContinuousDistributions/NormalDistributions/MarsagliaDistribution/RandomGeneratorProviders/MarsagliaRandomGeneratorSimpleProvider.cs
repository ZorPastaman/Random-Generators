// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Simple Provider",
		fileName = "Marsaglia Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private MarsagliaRandomGeneratorSimple m_MarsagliaRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="MarsagliaRandomGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new MarsagliaRandomGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_MarsagliaRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="MarsagliaRandomGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaRandomGeneratorSimple marsagliaRandomGenerator
		{
			[Pure]
			get => new MarsagliaRandomGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaRandomGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public MarsagliaRandomGeneratorSimple sharedMarsagliaRandomGenerator
		{
			[Pure]
			get => m_MarsagliaRandomGenerator;
		}
	}
}
