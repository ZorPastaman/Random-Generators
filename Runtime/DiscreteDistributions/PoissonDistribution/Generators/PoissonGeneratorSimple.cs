// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate(float)"/>.
	/// </summary>
	[Serializable]
	public sealed class PoissonGeneratorSimple : IPoissonGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Lambda = PoissonDistribution.DefaultLambda;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorSimple"/> with the default parameters.
		/// </summary>
		public PoissonGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		public PoissonGeneratorSimple(float lambda)
		{
			m_Lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorSimple([NotNull] PoissonGeneratorSimple other)
		{
			m_Lambda = other.m_Lambda;
		}

		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Lambda;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Lambda = value;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => PoissonDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return PoissonDistribution.Generate(m_Lambda);
		}
	}
}
