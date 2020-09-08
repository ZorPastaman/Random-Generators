// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class AcceptanceRejectionCurveGeneratorDependentSimpleProvider :
		ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_ValueGeneratorProvider;
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
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
				m_ValueGeneratorProvider.generator, m_ProbabilityCurve);
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
				m_ValueGeneratorProvider.generator, m_ProbabilityCurve);
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

		public ContinuousGeneratorProviderReference valueGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ValueGeneratorProvider;
			set
			{
				if (m_ValueGeneratorProvider == value)
				{
					return;
				}

				m_ValueGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// X - generated value\nY - its probability\nAt least one point must have possibility 1.
		/// </summary>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ProbabilityCurve;
			set
			{
				if (m_ProbabilityCurve.Equals(value))
				{
					return;
				}

				m_ProbabilityCurve = value;
				m_sharedGenerator = null;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
