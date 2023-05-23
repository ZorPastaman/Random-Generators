// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate{TValue,TCheck}(TValue,TCheck,AnimationCurve)"/>.
	/// </summary>
	public sealed class RejectionCurveGeneratorDependent<TValue, TCheck> : IRejectionGenerator
		where TValue : IContinuousGenerator where TCheck : IContinuousGenerator
	{
		[NotNull] private TValue m_valueGenerator;
		[NotNull] private TCheck m_checkGenerator;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public RejectionCurveGeneratorDependent([NotNull] TValue valueGenerator,
			[NotNull] TCheck checkGenerator, [NotNull] AnimationCurve probabilityCurve)
		{
			m_valueGenerator = valueGenerator;
			m_checkGenerator = checkGenerator;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionCurveGeneratorDependent([NotNull] RejectionCurveGeneratorDependent<TValue, TCheck> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_checkGenerator = other.m_checkGenerator;
			m_probabilityCurve = other.m_probabilityCurve;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public TValue valueGenerator
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
		public TCheck checkGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_checkGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_checkGenerator = value;
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
			return RejectionDistribution.Generate(m_valueGenerator, m_checkGenerator, m_probabilityCurve);
		}
	}
}
