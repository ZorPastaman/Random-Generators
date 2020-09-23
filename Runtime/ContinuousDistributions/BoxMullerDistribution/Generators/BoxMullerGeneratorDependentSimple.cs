// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate{T}(T)"/>.
	/// </summary>
	public sealed class BoxMullerGeneratorDependentSimple<T> : IBoxMullerGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorDependentSimple{T}"/> with
		/// the specified parameter.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BoxMullerGeneratorDependentSimple([NotNull] T dependedGenerator)
		{
			m_dependedGenerator = dependedGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerGeneratorDependentSimple([NotNull] BoxMullerGeneratorDependentSimple<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_dependedGenerator = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BoxMullerDistribution.DefaultMean;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BoxMullerDistribution.DefaultDeviation;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = BoxMullerDistribution.Generate(m_dependedGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
