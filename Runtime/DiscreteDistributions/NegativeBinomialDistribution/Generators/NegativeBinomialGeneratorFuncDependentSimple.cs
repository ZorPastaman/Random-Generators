// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		private byte m_failures;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		public NegativeBinomialGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc,
			float probability, byte failures)
		{
			m_iidFunc = iidFunc;
			m_probability = probability;
			m_failures = failures;
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
			m_failures = other.m_failures;
		}

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

		public byte failures
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_failures;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_failures = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_iidFunc, m_probability, m_failures);
		}
	}
}
