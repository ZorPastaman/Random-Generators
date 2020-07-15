// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	public sealed class MarsagliaRandomGeneratorFuncDependentSimple : IMarsagliaRandomGenerator
	{
		private Func<float> m_iidFunc;

		private float m_spared;
		private bool m_hasSpared;

		public MarsagliaRandomGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc)
		{
			m_iidFunc = iidFunc;
		}

		public MarsagliaRandomGeneratorFuncDependentSimple([NotNull] MarsagliaRandomGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
		}

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
