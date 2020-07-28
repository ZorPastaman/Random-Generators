// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(AnimationCurve)"/>.
	/// </summary>
	[Serializable]
	public sealed class AcceptanceRejectionCurveGeneratorSimple : IAcceptanceRejectionGenerator
	{
#pragma warning disable CS0649
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGenerator"/> with the default parameters.
		/// </summary>
		/// <remarks>
		/// Probability curve must be set by Unity serialization or via <see cref="probabilityCurve"/>.
		/// </remarks>
		public AcceptanceRejectionCurveGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionCurveGeneratorSimple([NotNull] AnimationCurve probabilityCurve)
		{
			m_ProbabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveGeneratorSimple([NotNull] AcceptanceRejectionCurveGeneratorSimple other)
		{
			m_ProbabilityCurve = other.m_ProbabilityCurve;
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
			[Pure]
			get => m_ProbabilityCurve;
			set => m_ProbabilityCurve = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_ProbabilityCurve);
		}
	}
}
