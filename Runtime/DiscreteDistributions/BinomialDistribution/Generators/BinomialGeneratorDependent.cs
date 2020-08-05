// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Binomial Random Generator using <see cref="BinomialDistribution.Generate{T}(T,int,float,byte)"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class BinomialGeneratorDependent<T> : IBinomialGenerator where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private int m_startPoint;
		private float m_p;
		private byte m_n;

		/// <summary>
		/// Creates a <see cref="BinomialGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator"></param>
		/// <param name="startPoint"></param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		public BinomialGeneratorDependent([NotNull] T iidGenerator, int startPoint, float p, byte n)
		{
			m_iidGenerator = iidGenerator;
			m_startPoint = startPoint;
			m_p = p;
			m_n = n;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public BinomialGeneratorDependent([NotNull] BinomialGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_startPoint = other.m_startPoint;
			m_p = other.m_p;
			m_n = other.m_n;
		}

		[NotNull]
		public T iidGenerator
		{
			[Pure]
			get => m_iidGenerator;
			set => m_iidGenerator = value;
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

		[Pure]
		public int Generate()
		{
			return BinomialDistribution.Generate(m_iidGenerator, m_startPoint, m_p, m_n);
		}
	}
}
