// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

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
		[SerializeField, Range(NumberConstants.NormalEpsilon , 1f)]
		private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField, SimpleRangeInt(1, 255)]
		private byte m_Successes = NegativeBinomialDistribution.DefaultSuccesses;
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
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		public NegativeBinomialGenerator(int startPoint, float probability, byte successes)
		{
			m_StartPoint = startPoint;
			m_Probability = probability;
			m_Successes = successes;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGenerator([NotNull] NegativeBinomialGenerator other)
		{
			m_StartPoint = other.m_StartPoint;
			m_Probability = other.m_Probability;
			m_Successes = other.m_Successes;
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

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte successes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Successes;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Successes = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_StartPoint, m_Probability, m_Successes);
		}
	}
}
