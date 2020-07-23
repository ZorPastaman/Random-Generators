// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		public override IContinuousRandomGenerator randomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorSimple(m_AcceptanceRejectionRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_AcceptanceRejectionRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/> and returns it.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorSimple acceptanceRejectionRandomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorSimple(m_AcceptanceRejectionRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGeneratorSimple"/>.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorSimple sharedAcceptanceRejectionRandomGenerator =>
			m_AcceptanceRejectionRandomGenerator;
	}
}
