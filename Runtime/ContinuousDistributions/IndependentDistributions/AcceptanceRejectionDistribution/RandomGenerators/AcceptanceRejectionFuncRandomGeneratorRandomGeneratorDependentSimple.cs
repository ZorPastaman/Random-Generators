// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate{T}(T,Func{float,float}"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependentSimple<T> :
		IAcceptanceRejectionRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_valueGenerator;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependentSimple([NotNull] T valueGenerator,
			[NotNull] Func<float, float> probabilityFunc)
		{
			m_valueGenerator = valueGenerator;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependentSimple<T> other)
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
			[Pure]
			get => m_valueGenerator;
			set => m_valueGenerator = value;
		}

		/// <summary>
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </summary>
		[NotNull]
		public Func<float, float> probabilityFunc
		{
			[Pure]
			get => m_probabilityFunc;
			set => m_probabilityFunc = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_valueGenerator, m_probabilityFunc);
		}
	}
}
