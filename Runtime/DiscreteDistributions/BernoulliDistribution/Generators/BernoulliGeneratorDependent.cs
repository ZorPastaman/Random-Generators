// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Bernoulli Random Generator using <see cref="BernoulliDistribution.Generate{T}(T,float)"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class BernoulliGeneratorDependent<T> : IBernoulliGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_probability;

		/// <summary>
		/// Creates a <see cref="BernoulliGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		public BernoulliGeneratorDependent([NotNull] T iidGenerator, float probability)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGeneratorDependent([NotNull] BernoulliGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_probability = other.m_probability;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
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
			return BernoulliDistribution.Generate(m_iidGenerator, m_probability);
		}
	}
}
