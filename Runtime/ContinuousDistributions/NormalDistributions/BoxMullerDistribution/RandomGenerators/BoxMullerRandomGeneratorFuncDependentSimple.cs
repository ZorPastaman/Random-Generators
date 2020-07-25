// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate(Func{float})"/>.
	/// </summary>
	public sealed class BoxMullerRandomGeneratorFuncDependentSimple : IBoxMullerRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="BoxMullerRandomGeneratorFuncDependentSimple"/> with the specified parameter.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerRandomGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc)
		{
			m_iidFunc = iidFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerRandomGeneratorFuncDependentSimple([NotNull] BoxMullerRandomGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[Pure]
			get => m_iidFunc;
			set
			{
				m_iidFunc = value;
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
			(answer, m_spared) = BoxMullerDistribution.Generate(m_iidFunc);
			m_hasSpared = true;

			return answer;
		}
	}
}
