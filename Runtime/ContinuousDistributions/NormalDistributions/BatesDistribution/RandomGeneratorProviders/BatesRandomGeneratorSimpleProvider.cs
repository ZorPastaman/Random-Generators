// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Random Generator Simple Provider",
		fileName = "Bates Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BatesRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BatesRandomGeneratorSimple m_BatesRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new BatesRandomGeneratorSimple(m_BatesRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_BatesRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorSimple batesRandomGenerator => new BatesRandomGeneratorSimple(m_BatesRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorSimple sharedBatesRandomGenerator => m_BatesRandomGenerator;
	}
}
