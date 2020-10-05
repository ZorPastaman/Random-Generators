// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator
	/// using <see cref="NegativeBinomialDistribution.Generate{T}(T,int,float,byte)"/>.
	/// </summary>
	public sealed class NegativeBinomialGeneratorDependent<T> : INegativeBinomialGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private int m_startPoint;
		private float m_probability;
		private byte m_failures;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="failures"></param>
		/// <remarks>
		/// <paramref name="failures"/> must be greater than 0.
		/// </remarks>
		public NegativeBinomialGeneratorDependent([NotNull] T iidGenerator,
			int startPoint, float probability, byte failures)
		{
			m_iidGenerator = iidGenerator;
			m_startPoint = startPoint;
			m_probability = probability;
			m_failures = failures;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorDependent([NotNull] NegativeBinomialGeneratorDependent<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_startPoint = other.m_startPoint;
			m_probability = other.m_probability;
			m_failures = other.m_failures;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
		}

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_startPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_startPoint = value;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte failures
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_failures;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_failures = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return NegativeBinomialDistribution.Generate(m_iidGenerator, m_startPoint, m_probability, m_failures);
		}
	}
}
