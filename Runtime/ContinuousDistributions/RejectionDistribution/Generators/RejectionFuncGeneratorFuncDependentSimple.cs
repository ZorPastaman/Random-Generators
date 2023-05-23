// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate(Func{float},Func{float,float})"/>.
	/// </summary>
	public sealed class RejectionFuncGeneratorFuncDependentSimple : IRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="RejectionFuncGeneratorFuncDependentSimple"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public RejectionFuncGeneratorFuncDependentSimple([NotNull] Func<float> valueFunc,
			[NotNull] Func<float, float> probabilityFunc)
		{
			m_valueFunc = valueFunc;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionFuncGeneratorFuncDependentSimple([NotNull] RejectionFuncGeneratorFuncDependentSimple other)
		{
			m_valueFunc = other.m_valueFunc;
			m_probabilityFunc = other.m_probabilityFunc;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public Func<float> valueFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valueFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_valueFunc = value;
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

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return RejectionDistribution.Generate(m_valueFunc, m_probabilityFunc);
		}
	}
}
