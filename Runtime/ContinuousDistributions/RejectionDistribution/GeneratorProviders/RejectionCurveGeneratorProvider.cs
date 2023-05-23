// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="RejectionCurveGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RejectionDistributionFolder + "Rejection Curve Generator Provider",
		fileName = "RejectionCurveGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class RejectionCurveGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
		[SerializeField] private float m_Min = RejectionDistribution.DefaultMin;
		[SerializeField] private float m_Max = RejectionDistribution.DefaultMax;
#pragma warning restore CS0649

		private RejectionCurveGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="RejectionCurveGenerator"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => rejectionGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="RejectionCurveGenerator"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedRejectionGenerator;

		/// <summary>
		/// Creates a new <see cref="RejectionCurveGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public RejectionCurveGenerator rejectionGenerator
		{
			[Pure]
			get => new RejectionCurveGenerator(m_ProbabilityCurve, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="RejectionCurveGenerator"/>.
		/// </summary>
		[NotNull]
		public RejectionCurveGenerator sharedRejectionGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = rejectionGenerator;
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

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
