// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator
	/// using <see cref="BinomialDistribution.Generate{T}(T,BinomialDistribution.Setup,byte)"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class BinomialGeneratorDependent<T> : IBinomialGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private BinomialDistribution.Setup m_setup;
		private byte m_upperBound;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		public BinomialGeneratorDependent([NotNull] T iidGenerator, float probability, byte upperBound)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
			m_setup = new BinomialDistribution.Setup(m_probability);
			m_upperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorDependent([NotNull] BinomialGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_setup = other.m_setup;
			m_upperBound = other.m_upperBound;
			m_probability = other.m_probability;
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
				m_setup = new BinomialDistribution.Setup(m_probability);
			}
		}

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_upperBound;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_upperBound = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_iidGenerator, m_setup, m_upperBound);
		}
	}
}
