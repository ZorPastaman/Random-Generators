// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate(AnimationCurve)"/>.
	/// </summary>
	public sealed class RejectionCurveGeneratorSimple : IRejectionGenerator
	{
		private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="RejectionCurveGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public RejectionCurveGeneratorSimple([NotNull] AnimationCurve probabilityCurve)
		{
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionCurveGeneratorSimple([NotNull] RejectionCurveGeneratorSimple other)
		{
			m_probabilityCurve = other.m_probabilityCurve;
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
			return RejectionDistribution.Generate(m_probabilityCurve);
		}
	}
}
