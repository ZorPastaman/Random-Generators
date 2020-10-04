// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate(Func{float},float,byte)"/>.
	/// </summary>
	public sealed class BinomialGeneratorFuncDependentSimple : IBinomialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_probability;
		private byte m_upperBound;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		public BinomialGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc, float probability, byte upperBound)
		{
			m_iidFunc = iidFunc;
			m_probability = probability;
			m_upperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorFuncDependentSimple([NotNull] BinomialGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
			m_probability = other.m_probability;
			m_upperBound = other.m_upperBound;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BinomialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_upperBound;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_upperBound = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_iidFunc, m_probability, m_upperBound);
		}
	}
}
