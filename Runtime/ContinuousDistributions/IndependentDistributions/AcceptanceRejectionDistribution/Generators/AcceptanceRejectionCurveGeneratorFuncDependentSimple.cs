// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float},AnimationCurve)"/>.
	/// </summary>
	public sealed class AcceptanceRejectionCurveGeneratorFuncDependentSimple : IAcceptanceRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGeneratorFuncDependentSimple"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionCurveGeneratorFuncDependentSimple([NotNull] Func<float> valueFunc,
			[NotNull] AnimationCurve probabilityCurve)
		{
			m_valueFunc = valueFunc;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveGeneratorFuncDependentSimple(
			[NotNull] AcceptanceRejectionCurveGeneratorFuncDependentSimple other)
		{
			m_valueFunc = other.m_valueFunc;
			m_probabilityCurve = other.m_probabilityCurve;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public Func<float> valueFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valueFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_valueFunc = value;
		}

		/// <summary>
		/// Check value source.
		/// </summary>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probabilityCurve;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probabilityCurve = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_valueFunc, m_probabilityCurve);
		}
	}
}
