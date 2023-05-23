// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator
	/// using <see cref="PoissonDistribution.Generate(Func{float},PoissonDistribution.Setup)"/>.
	/// </summary>
	public sealed class PoissonGeneratorFuncDependent : IPoissonGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private PoissonDistribution.Setup m_setup;

		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		public PoissonGeneratorFuncDependent([NotNull] Func<float> iidFunc, float lambda)
		{
			m_iidFunc = iidFunc;
			m_lambda = lambda;
			m_setup = new PoissonDistribution.Setup(m_lambda);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorFuncDependent([NotNull] PoissonGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_setup = other.m_setup;
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
			set
			{
				m_lambda = value;
				m_setup = new PoissonDistribution.Setup(m_lambda);
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return PoissonDistribution.Generate(m_iidFunc, m_setup);
		}
	}
}
