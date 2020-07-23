// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Random Generator Random Generator Dependent Simple Provider",
		fileName = "Acceptance-Rejection Curve Random Generator Random Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimpleProvider :
		ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_ValueRandomGenerator;
		[SerializeField] private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_ValueRandomGenerator.randomGenerator, m_ProbabilityCurve);

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = acceptanceRejectionRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			acceptanceRejectionRandomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_ValueRandomGenerator.randomGenerator, m_ProbabilityCurve);

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			sharedAcceptanceRejectionRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = acceptanceRejectionRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}
	}
}
