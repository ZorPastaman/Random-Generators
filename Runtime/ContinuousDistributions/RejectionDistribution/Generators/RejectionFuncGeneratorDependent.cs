// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Rejection Random Generator
	/// using <see cref="RejectionDistribution.Generate{TValue,TCheck}(TValue,TCheck,Func{float,float})"/>.
	/// </summary>
	public sealed class RejectionFuncGeneratorDependent<TValue, TCheck> : IRejectionGenerator
		where TValue : IContinuousGenerator where TCheck : IContinuousGenerator
	{
		[NotNull] private TValue m_valueGenerator;
		[NotNull] private TCheck m_checkGenerator;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="RejectionFuncGeneratorDependent{TValue,TCheck}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public RejectionFuncGeneratorDependent([NotNull] TValue valueGenerator,
			[NotNull] TCheck checkGenerator, [NotNull] Func<float, float> probabilityFunc)
		{
			m_valueGenerator = valueGenerator;
			m_checkGenerator = checkGenerator;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RejectionFuncGeneratorDependent([NotNull] RejectionFuncGeneratorDependent<TValue, TCheck> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_checkGenerator = other.m_checkGenerator;
			m_probabilityFunc = other.m_probabilityFunc;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public TValue valueGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valueGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_valueGenerator = value;
		}

		/// <summary>
		/// Check value source.
		/// </summary>
		[NotNull]
		public TCheck checkGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_checkGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_checkGenerator = value;
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
			return RejectionDistribution.Generate(m_valueGenerator, m_checkGenerator, m_probabilityFunc);
		}
	}
}
