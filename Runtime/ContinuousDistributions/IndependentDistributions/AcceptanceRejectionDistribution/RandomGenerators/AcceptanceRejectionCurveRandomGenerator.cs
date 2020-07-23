// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator using
	/// <see cref="AcceptanceRejectionDistribution.Generate(AnimationCurve,float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class AcceptanceRejectionCurveRandomGenerator : IAcceptanceRejectionRandomGenerator
	{
#pragma warning disable CS0649
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
		[SerializeField] private float m_Min;
		[SerializeField] private float m_Max = 1f;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveRandomGenerator"/> with the default parameters.
		/// </summary>
		/// <remarks>
		/// Probability curve must be set by Unity serialization or via <see cref="probabilityCurve"/>.
		/// </remarks>
		public AcceptanceRejectionCurveRandomGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveRandomGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionCurveRandomGenerator([NotNull] AnimationCurve probabilityCurve, float min, float max)
		{
			m_ProbabilityCurve = probabilityCurve;
			m_Min = min;
			m_Max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveRandomGenerator([NotNull] AcceptanceRejectionCurveRandomGenerator other)
		{
			m_ProbabilityCurve = other.m_ProbabilityCurve;
			m_Min = other.m_Min;
			m_Max = other.m_Max;
		}

		/// <summary>
		/// X - generated value, Y - its probability.
		/// </summary>
		/// <remarks>
		/// At least one point must have possibility 1.
		/// </remarks>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			get => m_ProbabilityCurve;
			set => m_ProbabilityCurve = value;
		}

		public float min
		{
			get => m_Min;
			set => m_Min = value;
		}

		public float max
		{
			get => m_Max;
			set => m_Max = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_ProbabilityCurve, m_Min, m_Max);
		}
	}
}
