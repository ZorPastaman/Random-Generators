// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate{T}(T)"/>.
	/// </summary>
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependentSimple<T> : IMarsagliaRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="dependedRandomGenerator"></param>
		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple([NotNull] T dependedRandomGenerator)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] MarsagliaRandomGeneratorRandomGeneratorDependentSimple<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[Pure]
			get => m_dependedRandomGenerator;
			set
			{
				m_dependedRandomGenerator = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			[Pure]
			get => MarsagliaDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
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
			(answer, m_spared) = MarsagliaDistribution.Generate(m_dependedRandomGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
