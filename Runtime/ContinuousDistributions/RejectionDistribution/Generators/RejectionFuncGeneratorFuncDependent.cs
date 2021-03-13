// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate(Func{float},Func{float},Func{float,float})"/>.
	/// </summary>
	public sealed class RejectionFuncGeneratorFuncDependent : IRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private Func<float> m_checkFunc;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="RejectionFuncGeneratorFuncDependent"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="checkFunc">Check value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public RejectionFuncGeneratorFuncDependent([NotNull] Func<float> valueFunc,
			[NotNull] Func<float> checkFunc, [NotNull] Func<float, float> probabilityFunc)
		{
			m_valueFunc = valueFunc;
			m_checkFunc = checkFunc;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionFuncGeneratorFuncDependent([NotNull] RejectionFuncGeneratorFuncDependent other)
		{
			m_valueFunc = other.m_valueFunc;
			m_checkFunc = other.m_checkFunc;
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
		/// Check value source.
		/// </summary>
		[NotNull]
		public Func<float> checkFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_checkFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_checkFunc = value;
		}

		/// <summary>
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
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
			return RejectionDistribution.Generate(m_valueFunc, m_checkFunc, m_probabilityFunc);
		}
	}
}
