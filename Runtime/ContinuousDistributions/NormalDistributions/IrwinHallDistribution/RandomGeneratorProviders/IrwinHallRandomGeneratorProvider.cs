// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallRandomGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Random Generator Provider",
		fileName = "Irwin-Hall Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private IrwinHallRandomGenerator m_IrwinHallRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGenerator"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new IrwinHallRandomGenerator(m_IrwinHallRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGenerator"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_IrwinHallRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallRandomGenerator irwinHallRandomGenerator
		{
			[Pure]
			get => new IrwinHallRandomGenerator(m_IrwinHallRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGenerator"/>.
		/// </summary>
		[NotNull]
		public IrwinHallRandomGenerator sharedIrwinHallRandomGenerator
		{
			[Pure]
			get => m_IrwinHallRandomGenerator;
		}
	}
}
