// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate(int,float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BinomialGenerator : IBinomialGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private int m_StartPoint = BinomialDistribution.DefaultStartPoint;
		[SerializeField, Range(0f, 0.999999881f)] private float m_Probability = BinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_UpperBound = BinomialDistribution.DefaultUpperBound;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="BinomialGenerator"/> with the default parameters.
		/// </summary>
		public BinomialGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="BinomialGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		public BinomialGenerator(int startPoint, float probability, byte upperBound)
		{
			m_StartPoint = startPoint;
			m_Probability = probability;
			m_UpperBound = upperBound;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGenerator([NotNull] BinomialGenerator other)
		{
			m_StartPoint = other.m_StartPoint;
			m_Probability = other.m_Probability;
			m_UpperBound = other.m_UpperBound;
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

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_UpperBound;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_UpperBound = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_StartPoint, m_Probability, m_UpperBound);
		}
	}
}
