// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate(Func{float,float})"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncRandomGeneratorSimple : IAcceptanceRejectionRandomGenerator
	{
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncRandomGeneratorSimple"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public AcceptanceRejectionFuncRandomGeneratorSimple([NotNull] Func<float, float> probabilityFunc)
		{
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncRandomGeneratorSimple(
			[NotNull] AcceptanceRejectionFuncRandomGeneratorSimple other)
		{
			m_probabilityFunc = other.m_probabilityFunc;
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
			return AcceptanceRejectionDistribution.Generate(m_probabilityFunc);
		}
	}
}
