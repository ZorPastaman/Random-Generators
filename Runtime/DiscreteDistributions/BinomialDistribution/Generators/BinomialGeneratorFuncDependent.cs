// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate(Func{float},int,float,byte)"/>.
	/// </summary>
	public sealed class BinomialGeneratorFuncDependent : IBinomialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private int m_startPoint;
		private float m_p;
		private byte m_n;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">Iid source in range [0, 1].</param>
		/// <param name="startPoint"></param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		public BinomialGeneratorFuncDependent([NotNull] Func<float> iidFunc, int startPoint, float p, byte n)
		{
			m_iidFunc = iidFunc;
			m_startPoint = startPoint;
			m_p = p;
			m_n = n;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorFuncDependent([NotNull] BinomialGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_startPoint = other.m_startPoint;
			m_p = other.m_p;
			m_n = other.m_n;
		}

		/// <summary>
		/// Iid source in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidGenerator
		{
			[Pure]
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		public int startPoint
		{
			[Pure]
			get => m_startPoint;
			set => m_startPoint = value;
		}

		/// <inheritdoc/>
		public float p
		{
			[Pure]
			get => m_p;
			set => m_p = value;
		}

		public byte n
		{
			[Pure]
			get => m_n;
			set => m_n = value;
		}

		/// <inheritdoc/>
		[Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_iidFunc, m_startPoint, m_p, m_n);
		}
	}
}
