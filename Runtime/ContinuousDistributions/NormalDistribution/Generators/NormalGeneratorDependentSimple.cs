// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Normal Random Generator using <see cref="NormalDistribution.Generate{T}(T)"/>.
	/// </summary>
	public sealed class NormalGeneratorDependentSimple<T> : INormalGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_iidGenerator;

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="NormalGeneratorDependentSimple{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		public NormalGeneratorDependentSimple([NotNull] T iidGenerator)
		{
			m_iidGenerator = iidGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public NormalGeneratorDependentSimple([NotNull] NormalGeneratorDependentSimple<T> other)
		{
			m_iidGenerator = other.m_iidGenerator;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_iidGenerator = value;
				m_hasSpared = false;
			}
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => NormalDistribution.DefaultMean;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => NormalDistribution.DefaultDeviation;
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
			(answer, m_spared) = NormalDistribution.Generate(m_iidGenerator);
			m_hasSpared = true;

			return answer;
		}
	}
}
