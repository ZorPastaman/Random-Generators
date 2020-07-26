// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Provider",
		fileName = "Irwin-Hall Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private IrwinHallGenerator m_IrwinHallGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IrwinHallGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new IrwinHallGenerator(m_IrwinHallGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_IrwinHallGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGenerator irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGenerator(m_IrwinHallGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGenerator"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGenerator sharedIrwinHallGenerator
		{
			[Pure]
			get => m_IrwinHallGenerator;
		}
	}
}
