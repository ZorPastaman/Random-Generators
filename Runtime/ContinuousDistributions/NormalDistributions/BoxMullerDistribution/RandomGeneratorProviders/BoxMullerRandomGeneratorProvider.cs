// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerRandomGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Random Generator Provider",
		fileName = "Box-Muller Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoxMullerRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BoxMullerRandomGenerator m_BoxMullerRandomGenerator;
#pragma warning disable CS0649

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGenerator"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new BoxMullerRandomGenerator(m_BoxMullerRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGenerator"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_BoxMullerRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerRandomGenerator boxMullerRandomGenerator
		{
			[Pure]
			get => new BoxMullerRandomGenerator(m_BoxMullerRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGenerator"/>.
		/// </summary>
		[NotNull]
		public BoxMullerRandomGenerator sharedBoxMullerRandomGenerator
		{
			[Pure]
			get => m_BoxMullerRandomGenerator;
		}
	}
}
