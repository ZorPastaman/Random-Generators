// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Bernoulli Random Generator using <see cref="BernoulliDistribution.Generate(Func{float},float)"/>.
	/// </summary>
	public sealed class BernoulliGeneratorFuncDependent : IBernoulliGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_p;

		/// <summary>
		/// Creates a <see cref="BernoulliGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">Iid source.</param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <remarks>
		/// <paramref name="iidFunc"/> must return independent and identically distributed random variable
		/// in range [0, 1].
		/// </remarks>
		public BernoulliGeneratorFuncDependent([NotNull] Func<float> iidFunc, float p)
		{
			m_iidFunc = iidFunc;
			m_p = p;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGeneratorFuncDependent([NotNull] BernoulliGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_p = other.m_p;
		}

		/// <summary>
		/// Independent and identically distributed random variable in range [0, 1] source.
		/// </summary>
		[NotNull]
		public Func<float> iidGenerator
		{
			[Pure]
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		/// <inheritdoc/>
		public float p
		{
			[Pure]
			get => m_p;
			set => m_p = value;
		}

		/// <inheritdoc/>
		[Pure]
		public bool Generate()
		{
			return BernoulliDistribution.Generate(m_iidFunc, m_p);
		}
	}
}
