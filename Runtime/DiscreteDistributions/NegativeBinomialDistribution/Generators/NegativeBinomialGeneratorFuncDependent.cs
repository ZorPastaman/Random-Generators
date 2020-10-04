// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Negative Binomial Random Generator
	/// using <see cref="NegativeBinomialDistribution.Generate(Func{float},int,float,byte)"/>.
	/// </summary>
	public sealed class NegativeBinomialGeneratorFuncDependent : INegativeBinomialGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private int m_startPoint;
		private float m_probability;
		private byte m_failures;

		/// <summary>
		/// Creates a <see cref="NegativeBinomialGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		public NegativeBinomialGeneratorFuncDependent([NotNull] Func<float> iidFunc,
			int startPoint, float probability, byte failures)
		{
			m_iidFunc = iidFunc;
			m_startPoint = startPoint;
			m_probability = probability;
			m_failures = failures;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public NegativeBinomialGeneratorFuncDependent([NotNull] NegativeBinomialGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_startPoint = other.m_startPoint;
			m_probability = other.m_probability;
			m_failures = other.m_failures;
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
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
			return NegativeBinomialDistribution.Generate(m_iidFunc, m_startPoint, m_probability, m_failures);
		}
	}
}