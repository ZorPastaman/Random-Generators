// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Random Generator Simple Provider",
		fileName = "Acceptance-Rejection Curve Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class AcceptanceRejectionCurveRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private AcceptanceRejectionCurveRandomGeneratorSimple m_AcceptanceRejectionRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveRandomGeneratorSimple(m_AcceptanceRejectionRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveRandomGeneratorSimple acceptanceRejectionRandomGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveRandomGeneratorSimple(m_AcceptanceRejectionRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveRandomGeneratorSimple sharedAcceptanceRejectionRandomGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionRandomGenerator;
		}
	}
}
