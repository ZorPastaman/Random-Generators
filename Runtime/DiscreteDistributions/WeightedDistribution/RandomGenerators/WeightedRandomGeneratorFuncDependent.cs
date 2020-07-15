// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate(Func{float},uint[],uint,int)"/>.
	/// </summary>
	public sealed class WeightedRandomGeneratorFuncDependent<T> : IWeightedRandomGenerator<T>
	{
		private Func<float> m_iidFunc;
		private readonly T[] m_values;
		private readonly uint[] m_weights;
		private readonly uint m_sum;
		private readonly int m_count;

		/// <summary>
		/// Creates a new <see cref="WeightedRandomGeneratorFuncDependent{TValue}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same.
		/// </remarks>
		public WeightedRandomGeneratorFuncDependent([NotNull] Func<float> iidFunc,
			[NotNull] T[] values, [NotNull] uint[] weights)
		{
			m_iidFunc = iidFunc;
			m_values = values;
			m_weights = weights;
			m_count = weights.Length;
			m_sum = WeightedDistribution.ComputeSum(weights, m_count);
		}

		public Func<float> iidFunc
		{
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		public int weightsCount => m_count;

		public uint GetWeight(int index)
		{
			return m_weights[index];
		}

		public T GetValue(int index)
		{
			return m_values[index];
		}

		/// <inheritdoc/>
		public T Generate()
		{
			int index = WeightedDistribution.Generate(m_iidFunc, m_weights, m_sum, m_count);
			return m_values[index];
		}
	}
}
