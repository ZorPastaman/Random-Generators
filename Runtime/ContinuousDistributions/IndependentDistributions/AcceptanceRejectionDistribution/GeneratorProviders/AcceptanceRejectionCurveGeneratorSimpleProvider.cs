// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGeneratorSimple"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorSimple(m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGeneratorSimple"/>
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
		/// Creates a new <see cref="AcceptanceRejectionCurveGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorSimple acceptanceRejectionGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGeneratorSimple(m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGeneratorSimple sharedAcceptanceRejectionGenerator
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
