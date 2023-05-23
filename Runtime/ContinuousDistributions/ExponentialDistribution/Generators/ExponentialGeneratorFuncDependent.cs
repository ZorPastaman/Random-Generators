// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate(Func{float},float)"/>.
	/// </summary>
	public sealed class ExponentialGeneratorFuncDependent : IExponentialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_lambda;

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGeneratorFuncDependent([NotNull] Func<float> iidFunc, float lambda)
		{
			m_iidFunc = iidFunc;
			m_lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGeneratorFuncDependent([NotNull] ExponentialGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_lambda = other.m_lambda;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
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

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExponentialDistribution.Generate(m_iidFunc, m_lambda);
		}
	}
}
