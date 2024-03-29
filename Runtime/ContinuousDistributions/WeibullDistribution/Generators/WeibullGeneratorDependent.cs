﻿// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="WeibullDistribution.Generate{T}(T,float,float)"/>.
	/// </summary>
	public sealed class WeibullGeneratorDependent<T> : IWeibullGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_alpha;
		private float m_beta;

		/// <summary>
		/// Creates a <see cref="WeibullGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		public WeibullGeneratorDependent([NotNull] T iidGenerator, float alpha, float beta)
		{
			m_iidGenerator = iidGenerator;
			m_alpha = alpha;
			m_beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public WeibullGeneratorDependent([NotNull] WeibullGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_alpha = other.m_alpha;
			m_beta = other.m_beta;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
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
			return WeibullDistribution.Generate(m_iidGenerator, m_alpha, m_beta);
		}
	}
}
