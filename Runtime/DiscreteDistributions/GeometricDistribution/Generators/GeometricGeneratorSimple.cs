// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator using <see cref="GeometricDistribution.Generate(float)"/>.
	/// </summary>
	[Serializable]
	public sealed class GeometricGeneratorSimple : IGeometricGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Range(NumberConstants.NormalEpsilon, NumberConstants.SubOne)]
		private float m_Probability = GeometricDistribution.DefaultProbability;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="GeometricGeneratorSimple"/> with the default parameters.
		/// </summary>
		public GeometricGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="GeometricGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		public GeometricGeneratorSimple(float probability)
		{
			m_Probability = probability;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGeneratorSimple([NotNull] GeometricGeneratorSimple other)
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

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => GeometricDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return GeometricDistribution.Generate(m_Probability);
		}
	}
}
