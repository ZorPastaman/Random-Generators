// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate{T}(T)"/>.
	/// </summary>
	public sealed class MarsagliaGeneratorDependentSimple<T> : IMarsagliaGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		public MarsagliaGeneratorDependentSimple([NotNull] T dependedGenerator)
		{
			m_dependedGenerator = dependedGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaGeneratorDependentSimple([NotNull] MarsagliaGeneratorDependentSimple<T> other)
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
			get => MarsagliaDistribution.DefaultMean;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => MarsagliaDistribution.DefaultDeviation;
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
			(answer, m_spared) = MarsagliaDistribution.Generate(m_dependedGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
