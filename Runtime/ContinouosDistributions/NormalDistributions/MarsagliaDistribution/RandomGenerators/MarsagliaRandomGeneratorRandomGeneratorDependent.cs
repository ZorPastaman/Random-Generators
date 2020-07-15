// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependent<T> : IMarsagliaRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		public MarsagliaRandomGeneratorRandomGeneratorDependent([NotNull] T dependedRandomGenerator,
			float mean, float deviation)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
			m_mean = mean;
			m_deviation = deviation;
		}

		public MarsagliaRandomGeneratorRandomGeneratorDependent(
			[NotNull] MarsagliaRandomGeneratorRandomGeneratorDependent<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
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

		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = MarsagliaDistribution.Generate(m_dependedRandomGenerator, m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
