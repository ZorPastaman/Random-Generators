// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Geometric Random Generator
	/// using <see cref="GeometricDistribution.Generate{T}(T,GeometricDistribution.Setup,int)"/>.
	/// </summary>
	public sealed class GeometricGeneratorDependent<T> : IGeometricGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private GeometricDistribution.Setup m_setup;
		private int m_startPoint;

		private float m_probability;

		/// <summary>
		/// Creates a <see cref="GeometricGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		public GeometricGeneratorDependent([NotNull] T iidGenerator, float probability, int startPoint)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
			m_setup = new GeometricDistribution.Setup(m_probability);
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GeometricGeneratorDependent([NotNull] GeometricGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_setup = other.m_setup;
			m_startPoint = other.m_startPoint;
			m_probability = other.m_probability;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
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
			return GeometricDistribution.Generate(m_iidGenerator, m_setup, m_startPoint);
		}
	}
}
