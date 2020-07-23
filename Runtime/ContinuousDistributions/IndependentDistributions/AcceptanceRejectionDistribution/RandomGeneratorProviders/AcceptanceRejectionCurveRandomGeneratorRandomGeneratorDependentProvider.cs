// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator,IContinuousRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Random Generator Random Generator Dependent Provider",
		fileName = "Acceptance-Rejection Curve Random Generator Random Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentProvider :
		ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_ValueRandomGenerator;
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_CheckRandomGenerator;
		[SerializeField] private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator,
			IContinuousRandomGenerator> m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator,IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator,
				IContinuousRandomGenerator>(
				m_ValueRandomGenerator.randomGenerator, m_CheckRandomGenerator.randomGenerator, m_ProbabilityCurve);

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator,IContinuousRandomGenerator}"/>
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
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator,IContinuousRandomGenerator}"/>
		/// and returns it.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator,
			IContinuousRandomGenerator> acceptanceRejectionRandomGenerator =>
			new AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator,
				IContinuousRandomGenerator>(
				m_ValueRandomGenerator.randomGenerator, m_CheckRandomGenerator.randomGenerator, m_ProbabilityCurve);

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator,IContinuousRandomGenerator}"/>.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator,
			IContinuousRandomGenerator> sharedAcceptanceRejectionRandomGenerator
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
