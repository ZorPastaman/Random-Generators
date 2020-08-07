// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides <see cref="AcceptanceRejectionCurveGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Generator Provider",
		fileName = "Acceptance-Rejection Curve Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class AcceptanceRejectionCurveGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private AcceptanceRejectionCurveGenerator m_AcceptanceRejectionGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGenerator"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGenerator(m_AcceptanceRejectionGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGenerator"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGenerator acceptanceRejectionGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGenerator(m_AcceptanceRejectionGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGenerator"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGenerator sharedAcceptanceRejectionGenerator
		{
			[Pure]
			get => m_AcceptanceRejectionGenerator;
		}
	}
}
