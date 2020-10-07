// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator using <see cref="NegativeBinomialDistribution.Generate(float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class NegativeBinomialGeneratorSimple : INegativeBinomialGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Range(1.19E-07f, 1f)]
		private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField, SimpleRangeInt(1, 255)]
		private byte m_Successes = NegativeBinomialDistribution.DefaultSuccesses;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorSimple"/> with the default parameters.
		/// </summary>
		public NegativeBinomialGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		public NegativeBinomialGeneratorSimple(float probability, byte successes)
		{
			m_Probability = probability;
			m_Successes = successes;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorSimple([NotNull] NegativeBinomialGeneratorSimple other)
		{
			m_Probability = other.m_Probability;
			m_Successes = other.m_Successes;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => NegativeBinomialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Probability = value;
		}

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte successes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Successes;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Successes = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_Probability, m_Successes);
		}
	}
}
