// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Poisson Random Generator using <see cref="PoissonDistribution.Generate{T}(T,float)"/>.
	/// </summary>
	public sealed class PoissonGeneratorDependent<T> : IPoissonGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_lambda;
		private int m_startPoint;

		/// <summary>
		/// Creates a <see cref="PoissonGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		public PoissonGeneratorDependent([NotNull] T iidGenerator, float lambda, int startPoint)
		{
			m_iidGenerator = iidGenerator;
			m_lambda = lambda;
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public PoissonGeneratorDependent([NotNull] PoissonGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_lambda = other.m_lambda;
			m_startPoint = other.m_startPoint;
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

		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_lambda;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_lambda = value;
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
			return PoissonDistribution.Generate(m_iidGenerator, m_lambda, m_startPoint);
		}
	}
}
