// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate{T}(T,PoissonDistribution.Setup)"/>.
	/// </summary>
	public sealed class PoissonGeneratorDependent<T> : IPoissonGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private PoissonDistribution.Setup m_setup;

		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		public PoissonGeneratorDependent([NotNull] T iidGenerator, float lambda)
		{
			m_iidGenerator = iidGenerator;
			m_lambda = lambda;
			m_setup = new PoissonDistribution.Setup(m_lambda);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorDependent([NotNull] PoissonGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_setup = other.m_setup;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
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
			return PoissonDistribution.Generate(m_iidGenerator, m_setup);
		}
	}
}
