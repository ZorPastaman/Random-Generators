// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate(Func{float})"/>.
	/// </summary>
	public sealed class MarsagliaGeneratorFuncDependentSimple : IMarsagliaGenerator
	{
		private Func<float> m_iidFunc;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public MarsagliaGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc)
		{
			m_iidFunc = iidFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaGeneratorFuncDependentSimple([NotNull] MarsagliaGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_iidFunc = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => MarsagliaDistribution.DefaultMean;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => MarsagliaDistribution.DefaultDeviation;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = MarsagliaDistribution.Generate(m_iidFunc);
			m_hasSpared = true;

			return answer;
		}
	}
}
