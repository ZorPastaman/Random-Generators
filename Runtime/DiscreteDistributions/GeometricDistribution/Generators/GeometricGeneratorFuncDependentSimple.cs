// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator
	/// using <see cref="GeometricDistribution.Generate(Func{float},GeometricDistribution.Setup)"/>.
	/// </summary>
	public sealed class GeometricGeneratorFuncDependentSimple : IGeometricGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private GeometricDistribution.Setup m_setup;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="GeometricGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		public GeometricGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc, float probability)
		{
			m_iidFunc = iidFunc;
			m_probability = probability;
			m_setup = new GeometricDistribution.Setup(m_probability);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGeneratorFuncDependentSimple([NotNull] GeometricGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
			m_setup = other.m_setup;
			m_probability = other.m_probability;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
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
				m_setup = new GeometricDistribution.Setup(m_probability);
			}
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
			return GeometricDistribution.Generate(m_iidFunc, m_setup);
		}
	}
}
