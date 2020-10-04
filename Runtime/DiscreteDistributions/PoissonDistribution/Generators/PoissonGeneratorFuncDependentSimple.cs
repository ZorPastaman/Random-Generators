// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate(Func{float},float)"/>.
	/// </summary>
	public sealed class PoissonGeneratorFuncDependentSimple : IPoissonGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		public PoissonGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc, float lambda)
		{
			m_iidFunc = iidFunc;
			m_lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorFuncDependentSimple([NotNull] PoissonGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
		}

		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_lambda;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_lambda = value;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => PoissonDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return PoissonDistribution.Generate(m_iidFunc, m_lambda);
		}
	}
}
