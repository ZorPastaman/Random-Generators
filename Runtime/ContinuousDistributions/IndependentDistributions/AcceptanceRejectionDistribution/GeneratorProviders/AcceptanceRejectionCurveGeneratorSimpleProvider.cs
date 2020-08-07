// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides <see cref="AcceptanceRejectionCurveGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Generator Simple Provider",
		fileName = "Acceptance-Rejection Curve Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class AcceptanceRejectionCurveGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private AcceptanceRejectionCurveGeneratorSimple m_AcceptanceRejectionGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGeneratorSimple"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorSimple(m_AcceptanceRejectionGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGeneratorSimple"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorSimple acceptanceRejectionRandomGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorSimple(m_AcceptanceRejectionGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorSimple sharedAcceptanceRejectionRandomGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionGenerator;
		}
	}
}
