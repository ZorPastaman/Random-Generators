// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate(float,int)"/>.
	/// </summary>
	[Serializable]
	public sealed class PoissonGenerator : IPoissonGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Lambda = 1f;
		[SerializeField] private int m_StartPoint = PoissonDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorSimple"/> with the default parameters.
		/// </summary>
		public PoissonGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		public PoissonGenerator(float lambda, int startPoint)
		{
			m_Lambda = lambda;
			m_StartPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGenerator([NotNull] PoissonGenerator other)
		{
			m_Lambda = other.m_Lambda;
			m_StartPoint = other.m_StartPoint;
		}

		public float lambda
		{
			[Pure]
			get => m_Lambda;
			set => m_Lambda = value;
		}

		public int startPoint
		{
			[Pure]
			get => m_StartPoint;
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		[Pure]
		public int Generate()
		{
			return PoissonDistribution.Generate(m_Lambda, m_StartPoint);
		}
	}
}