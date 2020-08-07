// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AcceptanceRejectionDistributionFolder + "Acceptance-Rejection Curve Generator Dependent Provider",
		fileName = "Acceptance-Rejection Curve Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class AcceptanceRejectionCurveGeneratorDependentProvider :
		ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_ValueGenerator;
		[SerializeField] private ContinuousGeneratorProviderReference m_CheckGenerator;
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>
			m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>(
				m_ValueGenerator.generator, m_CheckGenerator.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>
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
		/// <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>
			acceptanceRejectionGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>(
				m_ValueGenerator.generator, m_CheckGenerator.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>
			sharedAcceptanceRejectionGenerator
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
