// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate(Func{float})"/>.
	/// </summary>
	public sealed class MarsagliaRandomGeneratorFuncDependentSimple : IMarsagliaRandomGenerator
	{
		private Func<float> m_iidFunc;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaRandomGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public MarsagliaRandomGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc)
		{
			m_iidFunc = iidFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaRandomGeneratorFuncDependentSimple([NotNull] MarsagliaRandomGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		public Func<float> iidFunc
		{
			get => m_iidFunc;
			set
			{
				m_iidFunc = value;
				m_hasSpared = false;
			}
		}

		public float mean => MarsagliaDistribution.DefaultMean;

		public float deviation => MarsagliaDistribution.DefaultDeviation;

		/// <inheritdoc/>
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
