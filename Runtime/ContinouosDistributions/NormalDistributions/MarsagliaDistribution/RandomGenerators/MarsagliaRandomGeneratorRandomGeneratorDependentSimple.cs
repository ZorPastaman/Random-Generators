// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependentSimple<T> : IMarsagliaRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;

		private float m_spared;
		private bool m_hasSpared;

		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple([NotNull] T dependedRandomGenerator)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
		}

		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] MarsagliaRandomGeneratorRandomGeneratorDependentSimple<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
		}

		[NotNull]
		public T dependedRandomGenerator
		{
			get => m_dependedRandomGenerator;
			set
			{
				m_dependedRandomGenerator = value;
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
			(answer, m_spared) = MarsagliaDistribution.Generate(m_dependedRandomGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
