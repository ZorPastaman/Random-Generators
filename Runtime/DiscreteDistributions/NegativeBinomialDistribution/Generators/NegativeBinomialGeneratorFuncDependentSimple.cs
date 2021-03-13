// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator
	/// using <see cref="NegativeBinomialDistribution.Generate(Func{float},float,byte)"/>.
	/// </summary>
	public sealed class NegativeBinomialGeneratorFuncDependentSimple : INegativeBinomialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_probability;
		private byte m_successes;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range (0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="successes"></param>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		public NegativeBinomialGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc,
			float probability, byte successes)
		{
			m_iidFunc = iidFunc;
			m_probability = probability;
			m_successes = successes;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorFuncDependentSimple(
			[NotNull] NegativeBinomialGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
			m_probability = other.m_probability;
			m_successes = other.m_successes;
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

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => NegativeBinomialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte successes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_successes;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_successes = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_iidFunc, m_probability, m_successes);
		}
	}
}
