// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
		[SerializeField] private float m_Min = AcceptanceRejectionDistribution.DefaultMin;
		[SerializeField] private float m_Max = AcceptanceRejectionDistribution.DefaultMax;
#pragma warning restore CS0649

		private AcceptanceRejectionCurveGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="AcceptanceRejectionCurveGenerator"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGenerator(m_ProbabilityCurve, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGenerator"/>
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
		/// Creates a new <see cref="AcceptanceRejectionCurveGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGenerator acceptanceRejectionGenerator
		{
			[Pure]
			get => new AcceptanceRejectionCurveGenerator(m_ProbabilityCurve, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="AcceptanceRejectionCurveGenerator"/>.
		/// </summary>
		[NotNull]
		public AcceptanceRejectionCurveGenerator sharedAcceptanceRejectionGenerator
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
