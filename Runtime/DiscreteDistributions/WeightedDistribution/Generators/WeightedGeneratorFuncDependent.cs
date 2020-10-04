// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate(Func{float},uint[],uint,int)"/>.
	/// </summary>
	public sealed class WeightedGeneratorFuncDependent<T> : IWeightedGenerator<T>
	{
		[NotNull] private Func<float> m_iidFunc;
		[NotNull] private readonly T[] m_values;
		[NotNull] private readonly uint[] m_weights;
		private readonly uint m_sum;
		private readonly int m_count;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorFuncDependent{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGeneratorFuncDependent([NotNull] Func<float> iidFunc,
			[NotNull] T[] values, [NotNull] uint[] weights)
		{
			m_iidFunc = iidFunc;
			m_values = values;
			m_weights = weights;
			m_count = weights.Length;
			m_sum = WeightedDistribution.ComputeSum(weights, m_count);
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

		public int weightsCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_count;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public uint GetWeight(int index)
		{
			return m_weights[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public T GetValue(int index)
		{
			return m_values[index];
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public T Generate()
		{
			int index = WeightedDistribution.Generate(m_iidFunc, m_weights, m_sum, m_count);
			return m_values[index];
		}
	}
}
