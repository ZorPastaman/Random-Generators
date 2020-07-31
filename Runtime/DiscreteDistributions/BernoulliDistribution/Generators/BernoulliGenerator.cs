// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
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
		[SerializeField, Range(0f, 1f)] private float m_P = 0.5f;
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
		/// <param name="p">True threshold in range [0, 1].</param>
		public BernoulliGenerator(float p)
		{
			m_P = p;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BernoulliGenerator([NotNull] BernoulliGenerator other)
		{
			m_P = other.m_P;
		}

		/// <inheritdoc/>
		public float p
		{
			[Pure]
			get => m_P;
			set => m_P = value;
		}

		/// <inheritdoc/>
		[Pure]
		public bool Generate()
		{
			return BernoulliDistribution.Generate(m_P);
		}
	}
}
