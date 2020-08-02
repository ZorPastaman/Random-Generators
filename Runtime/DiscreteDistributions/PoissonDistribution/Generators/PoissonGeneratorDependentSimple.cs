// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate{T}(T,float)"/>.
	/// </summary>
	public sealed class PoissonGeneratorDependentSimple<T> : IPoissonGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		public PoissonGeneratorDependentSimple([NotNull] T iidGenerator, float lambda)
		{
			m_iidGenerator = iidGenerator;
			m_lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorDependentSimple([NotNull] PoissonGeneratorDependentSimple<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[Pure]
			get => m_iidGenerator;
			set => m_iidGenerator = value;
		}

		public float lambda
		{
			[Pure]
			get => m_lambda;
			set => m_lambda = value;
		}

		public int startPoint
		{
			[Pure]
			get => PoissonDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public int Generate()
		{
			return PoissonDistribution.Generate(m_iidGenerator, m_lambda);
		}
	}
}
