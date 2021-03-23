// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate(BinomialDistribution.Setup,byte)"/>.
	/// </summary>
	public sealed class BinomialGeneratorSimple : IBinomialGenerator
	{
		private BinomialDistribution.Setup m_setup;
		private byte m_upperBound;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		public BinomialGeneratorSimple(float probability, byte upperBound)
		{
			m_probability = probability;
			m_setup = new BinomialDistribution.Setup(m_probability);
			m_upperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorSimple([NotNull] BinomialGeneratorSimple other)
		{
			m_setup = other.m_setup;
			m_upperBound = other.m_upperBound;
			m_probability = other.m_probability;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => PoissonDistribution.DefaultStartPoint;
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

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_setup, m_upperBound);
		}
	}
}
