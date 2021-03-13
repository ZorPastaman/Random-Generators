// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate{T}(T,Func{float,float})"/>.
	/// </summary>
	public sealed class RejectionFuncGeneratorDependentSimple<T> : IRejectionGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_valueGenerator;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="RejectionFuncGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public RejectionFuncGeneratorDependentSimple([NotNull] T valueGenerator,
			[NotNull] Func<float, float> probabilityFunc)
		{
			m_valueGenerator = valueGenerator;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionFuncGeneratorDependentSimple([NotNull] RejectionFuncGeneratorDependentSimple<T> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_probabilityFunc = other.m_probabilityFunc;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public T valueGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valueGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_valueGenerator = value;
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
			return RejectionDistribution.Generate(m_valueGenerator, m_probabilityFunc);
		}
	}
}
