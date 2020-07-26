// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float},Func{float},Func{float,float}"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncGeneratorFuncDependent : IAcceptanceRejectionGenerator
	{
		[NotNull] private Func<float> m_valueFunc;
		[NotNull] private Func<float> m_checkFunc;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncGeneratorFuncDependent"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="checkFunc">Check value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public AcceptanceRejectionFuncGeneratorFuncDependent([NotNull] Func<float> valueFunc,
			[NotNull] Func<float> checkFunc, [NotNull] Func<float, float> probabilityFunc)
		{
			m_valueFunc = valueFunc;
			m_checkFunc = checkFunc;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncGeneratorFuncDependent(
			[NotNull] AcceptanceRejectionFuncGeneratorFuncDependent other)
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
			[Pure]
			get => m_valueFunc;
			set => m_valueFunc = value;
		}

		/// <summary>
		/// Check value source.
		/// </summary>
		[NotNull]
		public Func<float> checkFunc
		{
			[Pure]
			get => m_checkFunc;
			set => m_checkFunc = value;
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
			return AcceptanceRejectionDistribution.Generate(m_valueFunc, m_checkFunc, m_probabilityFunc);
		}
	}
}
