// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate{T}(T,float,byte)"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class BinomialGeneratorDependentSimple<T> : IBinomialGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_probability;
		private byte m_upperBound;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		public BinomialGeneratorDependentSimple([NotNull] T iidGenerator, float probability, byte upperBound)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
			m_upperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorDependentSimple([NotNull] BinomialGeneratorDependentSimple<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_probability = other.m_probability;
			m_upperBound = other.m_upperBound;
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

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BinomialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_upperBound;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_upperBound = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_iidGenerator, m_probability, m_upperBound);
		}
	}
}
