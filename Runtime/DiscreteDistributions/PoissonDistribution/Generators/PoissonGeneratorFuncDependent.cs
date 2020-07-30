// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate(Func{float},float)"/>.
	/// </summary>
	public sealed class PoissonGeneratorFuncDependent : IPoissonGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		public PoissonGeneratorFuncDependent([NotNull] Func<float> iidFunc, float lambda)
		{
			m_iidFunc = iidFunc;
			m_lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorFuncDependent([NotNull] PoissonGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[Pure]
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		public float lambda
		{
			[Pure]
			get => m_lambda;
			set => m_lambda = value;
		}

		/// <inheritdoc/>
		public int Generate()
		{
			return PoissonDistribution.Generate(m_iidFunc, m_lambda);
		}
	}
}
