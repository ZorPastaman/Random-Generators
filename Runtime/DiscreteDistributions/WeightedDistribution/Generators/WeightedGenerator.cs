// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate(uint[],uint,int)"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public sealed class WeightedGenerator<T> : IWeightedGenerator<T>
	{
		private readonly T[] m_values;
		private readonly uint[] m_weights;
		private readonly uint m_sum;
		private readonly int m_count;

		/// <summary>
		/// Creates a new <see cref="WeightedGenerator{T}"/> with the specified parameters.
		/// </summary>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGenerator([NotNull] T[] values, [NotNull] uint[] weights)
		{
			m_values = values;
			m_weights = weights;
			m_count = weights.Length;
			m_sum = WeightedDistribution.ComputeSum(weights, m_count);
		}

		public int weightsCount
		{
			[Pure]
			get => m_count;
		}

		[Pure]
		public uint GetWeight(int index)
		{
			return m_weights[index];
		}

		[Pure]
		public T GetValue(int index)
		{
			return m_values[index];
		}

		/// <inheritdoc/>
		[Pure]
		public T Generate()
		{
			int index = WeightedDistribution.Generate(m_weights, m_sum, m_count);
			return m_values[index];
		}
	}
}
