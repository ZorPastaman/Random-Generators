// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator
	/// using <see cref="NegativeBinomialDistribution.Generate{T}(T,float,byte)"/>.
	/// </summary>
	public sealed class NegativeBinomialGeneratorDependentSimple<T> : INegativeBinomialGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;
		private float m_probability;
		private byte m_failures;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		public NegativeBinomialGeneratorDependentSimple([NotNull] T iidGenerator, float probability, byte failures)
		{
			m_iidGenerator = iidGenerator;
			m_probability = probability;
			m_failures = failures;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorDependentSimple([NotNull] NegativeBinomialGeneratorDependentSimple<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
			m_probability = other.m_probability;
			m_failures = other.m_failures;
		}

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
			get => NegativeBinomialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_probability;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_probability = value;
		}

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
			return NegativeBinomialDistribution.Generate(m_iidGenerator, m_probability, m_failures);
		}
	}
}
