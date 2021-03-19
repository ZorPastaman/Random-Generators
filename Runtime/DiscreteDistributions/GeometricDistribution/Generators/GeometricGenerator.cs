// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator using <see cref="GeometricDistribution.Generate(float,int)"/>.
	/// </summary>
	[Serializable]
	public sealed class GeometricGenerator : IGeometricGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Range(NumberConstants.NormalEpsilon, NumberConstants.SubOne)]
		private float m_Probability = GeometricDistribution.DefaultProbability;
		[SerializeField] private int m_StartPoint = GeometricDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="GeometricGenerator"/> with the default parameters.
		/// </summary>
		public GeometricGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="GeometricGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		public GeometricGenerator(float probability, int startPoint)
		{
			m_Probability = probability;
			m_StartPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGenerator([NotNull] GeometricGenerator other)
		{
			m_Probability = other.m_Probability;
			m_StartPoint = other.m_StartPoint;
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
			get => m_StartPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return GeometricDistribution.Generate(m_Probability, m_StartPoint);
		}
	}
}
