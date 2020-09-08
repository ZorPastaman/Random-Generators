// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate(Func{float},float,float)"/>.
	/// </summary>
	public sealed class MarsagliaGeneratorFuncDependent : IMarsagliaGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		public MarsagliaGeneratorFuncDependent([NotNull] Func<float> iidFunc, float mean, float deviation)
		{
			m_iidFunc = iidFunc;
			m_mean = mean;
			m_deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaGeneratorFuncDependent([NotNull] MarsagliaGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
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
			get => m_mean;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_deviation;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_deviation = value;
				m_hasSpared = false;
			}
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
			(answer, m_spared) = MarsagliaDistribution.Generate(m_iidFunc, m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
