// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate{T}(T,float,float)"/>.
	/// </summary>
	public sealed class ExponentialGeneratorDependent<T> : IExponentialGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_lambda;
		private float m_startPoint;

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGeneratorDependent([NotNull] T iidGenerator, float lambda, float startPoint)
		{
			m_iidGenerator = iidGenerator;
			m_lambda = lambda;
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGeneratorDependent([NotNull] ExponentialGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_lambda = other.m_lambda;
			m_startPoint = other.m_startPoint;
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
			get => m_startPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_startPoint = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExponentialDistribution.Generate(m_iidGenerator, m_lambda, m_startPoint);
		}
	}
}
