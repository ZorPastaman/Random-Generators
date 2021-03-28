// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="WeibullDistribution.Generate(Func{float},float,float)"/>.
	/// </summary>
	public sealed class WeibullGeneratorFunc : IWeibullGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_alpha;
		private float m_beta;

		/// <summary>
		/// Creates a <see cref="WeibullGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		public WeibullGeneratorFunc([NotNull] Func<float> iidFunc, float alpha, float beta)
		{
			m_iidFunc = iidFunc;
			m_alpha = alpha;
			m_beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public WeibullGeneratorFunc([NotNull] WeibullGeneratorFunc other)
		{
			m_iidFunc = other.m_iidFunc;
			m_alpha = other.m_alpha;
			m_beta = other.m_beta;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
		}

		/// <summary>
		/// Shape. Must be non-zero.
		/// </summary>
		public float alpha
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_alpha;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_alpha = value;
		}

		/// <inheritdoc/>
		public float beta
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_beta;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_beta = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return WeibullDistribution.Generate(m_iidFunc, m_alpha, m_beta);
		}
	}
}
