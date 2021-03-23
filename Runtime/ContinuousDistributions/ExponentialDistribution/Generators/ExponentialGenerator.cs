// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate(float,float)"/>.
	/// </summary>
	public sealed class ExponentialGenerator : IExponentialGenerator
	{
		private float m_lambda;
		private float m_startPoint;

		/// <summary>
		/// Creates an <see cref="ExponentialGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGenerator(float lambda, float startPoint)
		{
			m_lambda = lambda;
			m_startPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGenerator([NotNull] ExponentialGenerator other)
		{
			m_lambda = other.m_lambda;
			m_startPoint = other.m_startPoint;
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
			return ExponentialDistribution.Generate(m_lambda, m_startPoint);
		}
	}
}
