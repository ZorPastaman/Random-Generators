// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
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
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new IrwinHallRandomGeneratorSimple(m_IrwinHallRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorSimple"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_IrwinHallRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallRandomGeneratorSimple irwinHallRandomGenerator
		{
			[Pure]
			get => new IrwinHallRandomGeneratorSimple(m_IrwinHallRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public IrwinHallRandomGeneratorSimple sharedIrwinHallRandomGenerator
		{
			[Pure]
			get => m_IrwinHallRandomGenerator;
		}
	}
}
