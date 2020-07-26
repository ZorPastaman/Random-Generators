// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Simple Provider",
		fileName = "Irwin-Hall Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private IrwinHallGeneratorSimple m_IrwinHallGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new IrwinHallGeneratorSimple(m_IrwinHallGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_IrwinHallGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorSimple irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGeneratorSimple(m_IrwinHallGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorSimple sharedIrwinHallGenerator
		{
			[Pure]
			get => m_IrwinHallGenerator;
		}
	}
}
