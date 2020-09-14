// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate(float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BinomialGeneratorSimple : IBinomialGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, 1f)] private float m_Probability = BinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_UpperBound = BinomialDistribution.DefaultUpperBound;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorSimple"/> with the default parameters.
		/// </summary>
		public BinomialGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		public BinomialGeneratorSimple(float probability, byte upperBound)
		{
			m_Probability = probability;
			m_UpperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorSimple([NotNull] BinomialGeneratorSimple other)
		{
			m_Probability = other.m_Probability;
			m_UpperBound = other.m_UpperBound;
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
			get => m_Probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Probability = value;
		}

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_UpperBound;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_UpperBound = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_Probability, m_UpperBound);
		}
	}
}
