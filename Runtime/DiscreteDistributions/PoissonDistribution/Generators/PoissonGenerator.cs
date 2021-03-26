// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate(PoissonDistribution.Setup)"/>.
	/// </summary>
	public sealed class PoissonGenerator : IPoissonGenerator
	{
		private PoissonDistribution.Setup m_setup;

		private float m_lambda;

		/// <summary>
		/// Creates a <see cref="PoissonGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		public PoissonGenerator(float lambda)
		{
			m_lambda = lambda;
			m_setup = new PoissonDistribution.Setup(m_lambda);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGenerator([NotNull] PoissonGenerator other)
		{
			m_setup = other.m_setup;
			m_lambda = other.m_lambda;
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
			return PoissonDistribution.Generate(m_setup);
		}
	}
}
