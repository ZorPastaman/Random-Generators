// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator using
	/// <see cref="RejectionDistribution.Generate(AnimationCurve,float,float)"/>.
	/// </summary>
	public sealed class RejectionCurveGenerator : IRejectionGenerator
	{
		private AnimationCurve m_probabilityCurve;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates an <see cref="RejectionCurveGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public RejectionCurveGenerator([NotNull] AnimationCurve probabilityCurve, float min, float max)
		{
			m_probabilityCurve = probabilityCurve;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionCurveGenerator([NotNull] RejectionCurveGenerator other)
		{
			m_probabilityCurve = other.m_probabilityCurve;
			m_min = other.m_min;
			m_max = other.m_max;
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return RejectionDistribution.Generate(m_probabilityCurve, m_min, m_max);
		}
	}
}
