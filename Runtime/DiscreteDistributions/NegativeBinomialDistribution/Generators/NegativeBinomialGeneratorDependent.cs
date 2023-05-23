// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator
	/// using <see cref="NegativeBinomialDistribution.Generate{T}(T,NegativeBinomialDistribution.Setup)"/>.
	/// </summary>
	public sealed class NegativeBinomialGeneratorDependent<T> : INegativeBinomialGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private NegativeBinomialDistribution.Setup m_setup;

		private float m_probability;
		private byte m_successes;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		public NegativeBinomialGeneratorDependent([NotNull] T iidGenerator, float probability, byte successes)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
			m_successes = successes;
			m_setup = new NegativeBinomialDistribution.Setup(m_probability, m_successes);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorDependent([NotNull] NegativeBinomialGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_setup = other.m_setup;
			m_probability = other.m_probability;
			m_successes = other.m_successes;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
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
			set
			{
				m_probability = value;
				m_setup = new NegativeBinomialDistribution.Setup(m_probability, m_successes);
			}
		}

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte successes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_successes;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_successes = value;
				m_setup = new NegativeBinomialDistribution.Setup(m_probability, m_successes);
			}
		}

		/// <summary>
		/// Sets probability and successes.
		/// </summary>
		/// <param name="newProbability">True threshold in range (0, 1].</param>
		/// <param name="newSuccesses">Successes. Must be greater than 0.</param>
		/// <remarks>
		/// If you need to set <see cref="probability"/> and <see cref="successes"/> at the same time,
		/// use this method because it recomputes setup data once.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetProbabilitySuccesses(float newProbability, byte newSuccesses)
		{
			m_probability = newProbability;
			m_successes = newSuccesses;
			m_setup = new NegativeBinomialDistribution.Setup(m_probability, m_successes);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_iidGenerator, m_setup);
		}
	}
}
