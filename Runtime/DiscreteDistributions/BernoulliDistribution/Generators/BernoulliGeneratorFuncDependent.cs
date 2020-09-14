// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Bernoulli Random Generator using <see cref="BernoulliDistribution.Generate(Func{float},float)"/>.
	/// </summary>
	public sealed class BernoulliGeneratorFuncDependent : IBernoulliGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_probability;

		/// <summary>
		/// Creates a <see cref="BernoulliGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">Iid source.</param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <remarks>
		/// <paramref name="iidFunc"/> must return independent and identically distributed random variable
		/// in range [0, 1].
		/// </remarks>
		public BernoulliGeneratorFuncDependent([NotNull] Func<float> iidFunc, float probability)
		{
			m_iidFunc = iidFunc;
			m_probability = probability;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGeneratorFuncDependent([NotNull] BernoulliGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_probability = other.m_probability;
		}

		/// <summary>
		/// Independent and identically distributed random variable in range [0, 1] source.
		/// </summary>
		[NotNull]
		public Func<float> iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool Generate()
		{
			return BernoulliDistribution.Generate(m_iidFunc, m_probability);
		}
	}
}
