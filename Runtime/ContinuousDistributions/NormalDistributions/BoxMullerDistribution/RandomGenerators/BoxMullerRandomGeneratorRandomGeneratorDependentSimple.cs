// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate{T}(T)"/>.
	/// </summary>
	public sealed class BoxMullerRandomGeneratorRandomGeneratorDependentSimple<T> : IBoxMullerRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{T}"/> with
		/// the specified parameter.
		/// </summary>
		/// <param name="dependedRandomGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerRandomGeneratorRandomGeneratorDependentSimple([NotNull] T dependedRandomGenerator)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] BoxMullerRandomGeneratorRandomGeneratorDependentSimple<T> other)
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
			get => BoxMullerDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
			get => BoxMullerDistribution.DefaultDeviation;
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
			(answer, m_spared) = BoxMullerDistribution.Generate(m_dependedRandomGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
