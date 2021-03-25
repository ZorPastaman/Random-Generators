// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate{T}(T,float)"/>.
	/// </summary>
	public sealed class ExponentialGeneratorDependentSimple<T> : IExponentialGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_lambda;

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGeneratorDependentSimple([NotNull] T iidGenerator, float lambda)
		{
			m_iidGenerator = iidGenerator;
			m_lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGeneratorDependentSimple([NotNull] ExponentialGeneratorDependentSimple<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
		}

		/// <summary>
		/// Lambda. Mustn't be zero.
		/// </summary>
		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_lambda;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_lambda = value;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => ExponentialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExponentialDistribution.Generate(m_iidGenerator, m_lambda);
		}
	}
}
