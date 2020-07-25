// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float},Func{float,float}"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncRandomGeneratorFuncDependentSimple : IAcceptanceRejectionRandomGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncRandomGeneratorFuncDependentSimple"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionFuncRandomGeneratorFuncDependentSimple([NotNull] Func<float> valueFunc,
			[NotNull] Func<float, float> probabilityFunc)
		{
			m_valueFunc = valueFunc;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncRandomGeneratorFuncDependentSimple(
			[NotNull] AcceptanceRejectionFuncRandomGeneratorFuncDependentSimple other)
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
			[Pure]
			get => m_valueFunc;
			set => m_valueFunc = value;
		}

		/// <summary>
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
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
			return AcceptanceRejectionDistribution.Generate(m_valueFunc, m_probabilityFunc);
		}
	}
}
