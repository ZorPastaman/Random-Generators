// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Gamma Generator using <see cref="GammaDistribution.Generate{T}(T,GammaDistribution.Setup,float)"/>.
	/// </summary>
	public sealed class GammaGeneratorDependent<T> : IGammaGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private GammaDistribution.Setup m_setup;
		private float m_beta;

		private float m_alpha;

		/// <summary>
		/// Creates a <see cref="GammaGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater or equal to 0.
		/// </remarks>
		public GammaGeneratorDependent([NotNull] T iidGenerator, float alpha, float beta)
		{
			m_iidGenerator = iidGenerator;
			m_alpha = alpha;
			m_setup = new GammaDistribution.Setup(m_alpha);
			m_beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GammaGeneratorDependent([NotNull] GammaGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_setup = other.m_setup;
			m_beta = other.m_beta;
			m_alpha = other.m_alpha;
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

		/// <inheritdoc/>
		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public float alpha
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_alpha;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_alpha = value;
				m_setup = new GammaDistribution.Setup(m_alpha);
			}
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
			return GammaDistribution.Generate(m_iidGenerator, m_setup, m_beta);
		}
	}
}
