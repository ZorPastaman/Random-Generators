// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Random Generator Simple Provider",
		fileName = "Irwin-Hall Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private IrwinHallRandomGeneratorSimple m_IrwinHallRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new IrwinHallRandomGeneratorSimple(m_IrwinHallRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_IrwinHallRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorSimple"/> and returns it.
		/// </summary>
		public IrwinHallRandomGeneratorSimple irwinHallRandomGenerator =>
			new IrwinHallRandomGeneratorSimple(m_IrwinHallRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorSimple"/>.
		/// </summary>
		public IrwinHallRandomGeneratorSimple sharedIrwinHallRandomGenerator => m_IrwinHallRandomGenerator;
	}
}
