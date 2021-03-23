// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator using <see cref="GeometricDistribution.Generate(GeometricDistribution.Setup,int)"/>.
	/// </summary>
	public sealed class GeometricGenerator : IGeometricGenerator
	{
		private GeometricDistribution.Setup m_setup;
		private int m_startPoint;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="GeometricGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		public GeometricGenerator(float probability, int startPoint)
		{
			m_probability = probability;
			m_setup = new GeometricDistribution.Setup(m_probability);
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGenerator([NotNull] GeometricGenerator other)
		{
			m_setup = other.m_setup;
			m_startPoint = other.m_startPoint;
			m_probability = other.m_probability;
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
			get => m_startPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_startPoint = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return GeometricDistribution.Generate(m_setup, m_startPoint);
		}
	}
}
