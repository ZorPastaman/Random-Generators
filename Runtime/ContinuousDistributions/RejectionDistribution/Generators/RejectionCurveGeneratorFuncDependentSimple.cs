// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate(Func{float},AnimationCurve)"/>.
	/// </summary>
	public sealed class RejectionCurveGeneratorFuncDependentSimple : IRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="RejectionCurveGeneratorFuncDependentSimple"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public RejectionCurveGeneratorFuncDependentSimple([NotNull] Func<float> valueFunc,
			[NotNull] AnimationCurve probabilityCurve)
		{
			m_valueFunc = valueFunc;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionCurveGeneratorFuncDependentSimple([NotNull] RejectionCurveGeneratorFuncDependentSimple other)
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
			return RejectionDistribution.Generate(m_valueFunc, m_probabilityCurve);
		}
	}
}
