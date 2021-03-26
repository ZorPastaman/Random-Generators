// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Gamma Generator using <see cref="GammaDistribution.Generate(GammaDistribution.Setup,float)"/>.
	/// </summary>
	public sealed class GammaGenerator : IGammaGenerator
	{
		private GammaDistribution.Setup m_setup;
		private float m_beta;

		private float m_alpha;

		/// <summary>
		/// Creates a <see cref="GammaGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		public GammaGenerator(float alpha, float beta)
		{
			m_alpha = alpha;
			m_setup = new GammaDistribution.Setup(m_alpha);
			m_beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GammaGenerator([NotNull] GammaGenerator other)
		{
			m_setup = other.m_setup;
			m_beta = other.m_beta;
			m_alpha = other.m_alpha;
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
			return GammaDistribution.Generate(m_setup, m_beta);
		}
	}
}
