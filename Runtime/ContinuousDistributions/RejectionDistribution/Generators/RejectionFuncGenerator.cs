// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate(Func{float,float},float,float)"/>.
	/// </summary>
	public sealed class RejectionFuncGenerator : IRejectionGenerator
	{
		[NotNull] private Func<float, float> m_probabilityFunc;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates an <see cref="RejectionFuncGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public RejectionFuncGenerator([NotNull] Func<float, float> probabilityFunc, float min, float max)
		{
			m_probabilityFunc = probabilityFunc;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionFuncGenerator([NotNull] RejectionFuncGenerator other)
		{
			m_probabilityFunc = other.m_probabilityFunc;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		/// <summary>
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </summary>
		[NotNull]
		public Func<float, float> probabilityFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probabilityFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probabilityFunc = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return RejectionDistribution.Generate(m_probabilityFunc, m_min, m_max);
		}
	}
}
