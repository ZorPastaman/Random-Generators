// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="AcceptanceRejectionCurveGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Generator Dependent Simple Provider",
		fileName = "Acceptance-Rejection Curve Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class AcceptanceRejectionCurveGeneratorDependentSimpleProvider :
		ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_ValueGenerator;
		[SerializeField] private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveGeneratorDependentSimple<IContinuousGenerator>
			m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorDependentSimple<IContinuousGenerator>(
				m_ValueGenerator.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = acceptanceRejectionGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorDependentSimple<IContinuousGenerator> acceptanceRejectionGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorDependentSimple<IContinuousGenerator>(
				m_ValueGenerator.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorDependentSimple<IContinuousGenerator> sharedAcceptanceRejectionGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = acceptanceRejectionGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
