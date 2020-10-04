// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator using <see cref="NegativeBinomialDistribution.Generate(int,float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class NegativeBinomialGenerator : INegativeBinomialGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private int m_StartPoint = NegativeBinomialDistribution.DefaultStartPoint;
		[SerializeField, Range(0f, 1f)] private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_Failures = NegativeBinomialDistribution.DefaultFailures;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGenerator"/> with the default parameters.
		/// </summary>
		public NegativeBinomialGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		public NegativeBinomialGenerator(int startPoint, float probability, byte failures)
		{
			m_StartPoint = startPoint;
			m_Probability = probability;
			m_Failures = failures;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGenerator([NotNull] NegativeBinomialGenerator other)
		{
			m_StartPoint = other.m_StartPoint;
			m_Probability = other.m_Probability;
			m_Failures = other.m_Failures;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_StartPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Probability = value;
		}

		public byte failures
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Failures;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Failures = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_StartPoint, m_Probability, m_Failures);
		}
	}
}