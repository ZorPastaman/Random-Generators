// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Bernoulli Random Generator using <see cref="BernoulliDistribution.Generate(float)"/>.
	/// </summary>
	[Serializable]
	public sealed class BernoulliGenerator : IBernoulliGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, 1f)] private float m_Probability = BernoulliDistribution.DefaultProbability;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="BernoulliGenerator"/> with the default parameters.
		/// </summary>
		public BernoulliGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="BernoulliGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		public BernoulliGenerator(float probability)
		{
			m_Probability = probability;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGenerator([NotNull] BernoulliGenerator other)
		{
			m_Probability = other.m_Probability;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Probability = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool Generate()
		{
			return BernoulliDistribution.Generate(m_Probability);
		}
	}
}
