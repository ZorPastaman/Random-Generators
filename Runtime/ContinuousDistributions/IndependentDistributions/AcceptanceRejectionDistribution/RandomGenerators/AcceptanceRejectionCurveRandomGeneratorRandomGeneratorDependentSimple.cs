// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate{T}(T,AnimationCurve)"/>.
	/// </summary>
	public sealed class AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<T> :
		IAcceptanceRejectionRandomGenerator where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_valueGenerator;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator"></param>
		/// <param name="probabilityCurve"></param>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple([NotNull] T valueGenerator,
			[NotNull] AnimationCurve probabilityCurve)
		{
			m_valueGenerator = valueGenerator;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] AcceptanceRejectionCurveRandomGeneratorRandomGeneratorDependentSimple<T> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_probabilityCurve = other.m_probabilityCurve;
		}

		/// <summary>
		/// Generated value source.
		/// </summary>
		[NotNull]
		public T valueGenerator
		{
			get => m_valueGenerator;
			set => m_valueGenerator = value;
		}

		/// <summary>
		/// Check value source.
		/// </summary>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			get => m_probabilityCurve;
			set => m_probabilityCurve = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_valueGenerator, m_probabilityCurve);
		}
	}
}
