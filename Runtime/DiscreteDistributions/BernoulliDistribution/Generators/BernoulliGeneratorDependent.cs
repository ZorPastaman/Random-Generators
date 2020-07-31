// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		private float m_p;

		/// <summary>
		/// Creates a <see cref="BernoulliGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">Iid source.</param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <remarks>
		/// <paramref name="iidGenerator"/> must return independent and identically distributed random variable
		/// in range [0, 1].
		/// </remarks>
		public BernoulliGeneratorDependent([NotNull] T iidGenerator, float p)
		{
			m_iidGenerator = iidGenerator;
			m_p = p;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGeneratorDependent([NotNull] BernoulliGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_p = other.m_p;
		}

		/// <summary>
		/// Independent and identically distributed random variable in range [0, 1] source.
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[Pure]
			get => m_iidGenerator;
			set => m_iidGenerator = value;
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
			return BernoulliDistribution.Generate(m_iidGenerator, m_p);
		}
	}
}
