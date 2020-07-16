// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate(Func{float},float,float)"/>.
	/// </summary>
	public sealed class BoxMullerRandomGeneratorFuncDependent : IBoxMullerRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="BoxMullerRandomGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerRandomGeneratorFuncDependent([NotNull] Func<float> iidFunc, float mean, float deviation)
		{
			m_iidFunc = iidFunc;
			m_mean = mean;
			m_deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerRandomGeneratorFuncDependent([NotNull] BoxMullerRandomGeneratorFuncDependent other)
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
			get => m_iidFunc;
			set
			{
				m_iidFunc = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			get => m_mean;
			set
			{
				m_mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			get => m_deviation;
			set
			{
				m_deviation = value;
				m_hasSpared = false;
			}
		}

		/// <inheritdoc/>
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = BoxMullerDistribution.Generate(m_iidFunc, m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
