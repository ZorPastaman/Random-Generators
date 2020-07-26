// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate{T}(T,float,float)"/>.
	/// </summary>
	public sealed class BoxMullerGeneratorDependent<T> : IBoxMullerGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private float m_mean;
		private float m_deviation;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="BoxMullerGeneratorDependent{T}"/> with
		/// the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerGeneratorDependent([NotNull] T dependedGenerator, float mean, float deviation)
		{
			m_dependedGenerator = dependedGenerator;
			m_mean = mean;
			m_deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerGeneratorDependent([NotNull] BoxMullerGeneratorDependent<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[Pure]
			get => m_dependedGenerator;
			set
			{
				m_dependedGenerator = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			[Pure]
			get => m_mean;
			set
			{
				m_mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			[Pure]
			get => m_deviation;
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
			(answer, m_spared) = BoxMullerDistribution.Generate(m_dependedGenerator, m_mean, m_deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
