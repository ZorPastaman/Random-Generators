// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate(Func{float},float,float)"/>.
	/// </summary>
	public sealed class ExponentialGeneratorFuncDependent : IExponentialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_lambda;
		private float m_startPoint;

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGeneratorFuncDependent([NotNull] Func<float> iidFunc, float lambda, float startPoint)
		{
			m_iidFunc = iidFunc;
			m_lambda = lambda;
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGeneratorFuncDependent([NotNull] ExponentialGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_lambda = other.m_lambda;
			m_startPoint = other.m_startPoint;
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
			return ExponentialDistribution.Generate(m_iidFunc, m_lambda, m_startPoint);
		}
	}
}
