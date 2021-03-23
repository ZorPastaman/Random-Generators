// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Bernoulli Random Generator using <see cref="BernoulliDistribution.Generate(float)"/>.
	/// </summary>
	public sealed class BernoulliGenerator : IBernoulliGenerator
	{
		private float m_probability;

		/// <summary>
		/// Creates a <see cref="BernoulliGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		public BernoulliGenerator(float probability)
		{
			m_probability = probability;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGenerator([NotNull] BernoulliGenerator other)
		{
			m_probability = other.m_probability;
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
			return BernoulliDistribution.Generate(m_probability);
		}
	}
}
