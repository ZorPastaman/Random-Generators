// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float},Func{float},AnimationCurve)"/>.
	/// </summary>
	public sealed class AcceptanceRejectionCurveGeneratorFuncDependent : IAcceptanceRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private Func<float> m_checkFunc;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="checkFunc">Check value source.</param>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionCurveGeneratorFuncDependent([NotNull] Func<float> valueFunc,
			[NotNull] Func<float> checkFunc, [NotNull] AnimationCurve probabilityCurve)
		{
			m_valueFunc = valueFunc;
			m_checkFunc = checkFunc;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveGeneratorFuncDependent(
			[NotNull] AcceptanceRejectionCurveGeneratorFuncDependent other)
		{
			m_valueFunc = other.m_valueFunc;
			m_checkFunc = other.m_checkFunc;
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
		public Func<float> checkFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_checkFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_checkFunc = value;
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
			get => m_probabilityCurve;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probabilityCurve = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_valueFunc, m_checkFunc, m_probabilityCurve);
		}
	}
}
