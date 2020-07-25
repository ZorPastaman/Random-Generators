// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides <see cref="AcceptanceRejectionCurveRandomGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Random Generator Provider",
		fileName = "Acceptance-Rejection Curve Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class AcceptanceRejectionCurveRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private AcceptanceRejectionCurveRandomGenerator m_AcceptanceRejectionRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveRandomGenerator"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveRandomGenerator(m_AcceptanceRejectionRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGenerator"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionRandomGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveRandomGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveRandomGenerator acceptanceRejectionRandomGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveRandomGenerator(m_AcceptanceRejectionRandomGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveRandomGenerator"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveRandomGenerator sharedAcceptanceRejectionRandomGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionRandomGenerator;
		}
	}
}
