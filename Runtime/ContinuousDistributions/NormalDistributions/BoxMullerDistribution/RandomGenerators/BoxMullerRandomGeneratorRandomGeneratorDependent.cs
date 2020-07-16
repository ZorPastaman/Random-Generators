// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate{T}(T,float,float)"/>.
	/// </summary>
	public sealed class BoxMullerRandomGeneratorRandomGeneratorDependent<T> : IBoxMullerRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{T}"/> with
		/// the specified parameters.
		/// </summary>
		/// <param name="dependedRandomGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerRandomGeneratorRandomGeneratorDependent([NotNull] T dependedRandomGenerator,
			float mean, float deviation)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
			m_mean = mean;
			m_deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependent(
			[NotNull] BoxMullerRandomGeneratorRandomGeneratorDependent<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
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

		/// <inheritdoc/>
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = BoxMullerDistribution.Generate(m_dependedRandomGenerator, m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
