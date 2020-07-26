// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate{T}(T,uint[],uint,int)"/>.
	/// </summary>
	/// <typeparam name="TValue">Value type.</typeparam>
	public sealed class WeightedGeneratorDependent<TValue, TGenerator> : IDiscreteGenerator<TValue>
		where TGenerator : IContinuousGenerator
	{
		[NotNull] private TGenerator m_dependedGenerator;
		private readonly TValue[] m_values;
		private readonly uint[] m_weights;
		private readonly uint m_sum;
		private readonly int m_count;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGeneratorDependent([NotNull] TGenerator dependedGenerator,
			[NotNull] TValue[] values, [NotNull] uint[] weights)
		{
			m_dependedGenerator = dependedGenerator;
			m_values = values;
			m_weights = weights;
			m_count = weights.Length;
			m_sum = WeightedDistribution.ComputeSum(weights, m_count);
		}

		[NotNull]
		public TGenerator dependedRandomGenerator
		{
			[Pure]
			get => m_dependedGenerator;
			set => m_dependedGenerator = value;
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
		public TValue GetValue(int index)
		{
			return m_values[index];
		}

		/// <inheritdoc/>
		[Pure]
		public TValue Generate()
		{
			int index = WeightedDistribution.Generate(m_dependedGenerator, m_weights, m_sum, m_count);
			return m_values[index];
		}
	}
}
