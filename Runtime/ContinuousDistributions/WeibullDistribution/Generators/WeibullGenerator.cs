// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="WeibullDistribution.Generate(float,float)"/>.
	/// </summary>
	public sealed class WeibullGenerator : IWeibullGenerator
	{
		private float m_alpha;
		private float m_beta;

		/// <summary>
		/// Creates a <see cref="WeibullGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		public WeibullGenerator(float alpha, float beta)
		{
			m_alpha = alpha;
			m_beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public WeibullGenerator([NotNull] WeibullGenerator other)
		{
			m_alpha = other.m_alpha;
			m_beta = other.m_beta;
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
			return WeibullDistribution.Generate(m_alpha, m_beta);
		}
	}
}
