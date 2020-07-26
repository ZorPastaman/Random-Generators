// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Acceptance-Rejection Random Generator
	/// using <see cref="AcceptanceRejectionDistribution.Generate{TValue,TCheck}(TValue,TCheck,AnimationCurve)"/>.
	/// </summary>
	public sealed class AcceptanceRejectionCurveGeneratorDependent<TValue, TCheck> : IAcceptanceRejectionGenerator
		where TValue : IContinuousGenerator where TCheck : IContinuousGenerator
	{
		[NotNull] private TValue m_valueGenerator;
		[NotNull] private TCheck m_checkGenerator;
		[NotNull] private AnimationCurve m_probabilityCurve;

		/// <summary>
		/// Creates an <see cref="AcceptanceRejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityCurve">
		/// <para>X - generated value, Y - its probability.</para>
		/// <para>At least one point must have possibility 1.</para>
		/// </param>
		public AcceptanceRejectionCurveGeneratorDependent([NotNull] TValue valueGenerator,
			[NotNull] TCheck checkGenerator, [NotNull] AnimationCurve probabilityCurve)
		{
			m_valueGenerator = valueGenerator;
			m_checkGenerator = checkGenerator;
			m_probabilityCurve = probabilityCurve;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public AcceptanceRejectionCurveGeneratorDependent(
			[NotNull] AcceptanceRejectionCurveGeneratorDependent<TValue, TCheck> other)
		{
			m_valueGenerator = other.m_valueGenerator;
			m_checkGenerator = other.m_checkGenerator;
			m_probabilityCurve = other.m_probabilityCurve;
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
		/// X - generated value, Y - its probability.
		/// </summary>
		/// <remarks>
		/// At least one point must have possibility 1.
		/// </remarks>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			[Pure]
			get => m_probabilityCurve;
			set => m_probabilityCurve = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return AcceptanceRejectionDistribution.Generate(m_valueGenerator, m_checkGenerator, m_probabilityCurve);
		}
	}
}
