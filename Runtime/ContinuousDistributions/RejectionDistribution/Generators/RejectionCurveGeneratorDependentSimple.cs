// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate{T}(T,AnimationCurve)"/>.
	/// </summary>
	public sealed class RejectionCurveGeneratorDependentSimple<T> : IRejectionGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_valueGenerator;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="RejectionCurveGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator"></param>
		/// <param name="probabilityCurve"></param>
		public RejectionCurveGeneratorDependentSimple([NotNull] T valueGenerator,
			[NotNull] AnimationCurve probabilityCurve)
		{
			m_valueGenerator = valueGenerator;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionCurveGeneratorDependentSimple([NotNull] RejectionCurveGeneratorDependentSimple<T> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_probabilityCurve = other.m_probabilityCurve;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public T valueGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valueGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_valueGenerator = value;
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
			return RejectionDistribution.Generate(m_valueGenerator, m_probabilityCurve);
		}
	}
}
