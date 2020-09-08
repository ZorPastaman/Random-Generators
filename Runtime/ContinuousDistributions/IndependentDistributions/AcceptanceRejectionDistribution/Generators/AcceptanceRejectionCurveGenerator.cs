// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator using
	/// <see cref="AcceptanceRejectionDistribution.Generate(AnimationCurve,float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class AcceptanceRejectionCurveGenerator : IAcceptanceRejectionGenerator
	{
#pragma warning disable CS0649
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
		[SerializeField] private float m_Min = AcceptanceRejectionDistribution.DefaultMin;
		[SerializeField] private float m_Max = AcceptanceRejectionDistribution.DefaultMax;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGenerator"/> with the default parameters.
		/// </summary>
		/// <remarks>
		/// Probability curve must be set by Unity serialization or via <see cref="probabilityCurve"/>.
		/// </remarks>
		public AcceptanceRejectionCurveGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public AcceptanceRejectionCurveGenerator([NotNull] AnimationCurve probabilityCurve, float min, float max)
		{
			m_ProbabilityCurve = probabilityCurve;
			m_Min = min;
			m_Max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveGenerator([NotNull] AcceptanceRejectionCurveGenerator other)
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ProbabilityCurve;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ProbabilityCurve = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_ProbabilityCurve, m_Min, m_Max);
		}
	}
}
