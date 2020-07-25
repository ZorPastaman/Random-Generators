// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate{TValue,TCheck}(TValue,TCheck,Func{float,float})"/>.
	/// </summary>
	public sealed class AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependent<TValue, TCheck> :
		IAcceptanceRejectionRandomGenerator
		where TValue : IContinuousRandomGenerator where TCheck : IContinuousRandomGenerator
	{
		[NotNull] private TValue m_valueGenerator;
		[NotNull] private TCheck m_checkGenerator;
		[NotNull] private Func<float, float> m_probabilityFunc;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependent{TValue,TCheck}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityFunc">
		/// <para>The argument is generated value, the result is its probability.</para>
		/// <para>At least one point must have max possibility.</para>
		/// </param>
		public AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependent([NotNull] TValue valueGenerator,
			[NotNull] TCheck checkGenerator, [NotNull] Func<float, float> probabilityFunc)
		{
			m_valueGenerator = valueGenerator;
			m_checkGenerator = checkGenerator;
			m_probabilityFunc = probabilityFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependent(
			[NotNull] AcceptanceRejectionFuncRandomGeneratorRandomGeneratorDependent<TValue, TCheck> other)
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
			[Pure]
			get => m_valueGenerator;
			set => m_valueGenerator = value;
		}

		/// <summary>
		/// Check value source.
		/// </summary>
		[NotNull]
		public TCheck checkGenerator
		{
			[Pure]
			get => m_checkGenerator;
			set => m_checkGenerator = value;
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
			return AcceptanceRejectionDistribution.Generate(m_valueGenerator, m_checkGenerator, m_probabilityFunc);
		}
	}
}
