// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
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
		[SerializeField, Range(0f, 1f)] private float m_P = 0.5f;
		[SerializeField] private byte m_N = 1;
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
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		public BinomialGenerator(int startPoint, float p, byte n)
		{
			m_StartPoint = startPoint;
			m_P = p;
			m_N = n;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGenerator([NotNull] BinomialGenerator other)
		{
			m_StartPoint = other.m_StartPoint;
			m_P = other.m_P;
			m_N = other.m_N;
		}

		public int startPoint
		{
			[Pure]
			get => m_StartPoint;
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		public float p
		{
			[Pure]
			get => m_P;
			set => m_P = value;
		}

		public byte n
		{
			[Pure]
			get => m_N;
			set => m_N = value;
		}

		/// <inheritdoc/>
		[Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_StartPoint, m_P, m_N);
		}
	}
}
