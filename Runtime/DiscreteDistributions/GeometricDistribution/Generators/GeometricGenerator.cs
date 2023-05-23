// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator using <see cref="GeometricDistribution.Generate(GeometricDistribution.Setup)"/>.
	/// </summary>
	public sealed class GeometricGenerator : IGeometricGenerator
	{
		private GeometricDistribution.Setup m_setup;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="GeometricGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		public GeometricGenerator(float probability)
		{
			m_probability = probability;
			m_setup = new GeometricDistribution.Setup(m_probability);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGenerator([NotNull] GeometricGenerator other)
		{
			m_setup = other.m_setup;
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

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return GeometricDistribution.Generate(m_setup);
		}
	}
}
