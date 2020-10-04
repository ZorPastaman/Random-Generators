// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate{T}(T,uint[],uint,int)"/>.
	/// </summary>
	/// <typeparam name="TValue">Value type.</typeparam>
	/// <typeparam name="TGenerator"></typeparam>
	public sealed class WeightedGeneratorDependent<TValue, TGenerator> : IDiscreteGenerator<TValue>
		where TGenerator : IContinuousGenerator
	{
		[NotNull] private TGenerator m_iidGenerator;
		[NotNull] private readonly TValue[] m_values;
		[NotNull] private readonly uint[] m_weights;
		private readonly uint m_sum;
		private readonly int m_count;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGeneratorDependent([NotNull] TGenerator iidGenerator,
			[NotNull] TValue[] values, [NotNull] uint[] weights)
		{
			m_iidGenerator = iidGenerator;
			m_values = values;
			m_weights = weights;
			m_count = weights.Length;
			m_sum = WeightedDistribution.ComputeSum(weights, m_count);
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public TGenerator iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
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
		public TValue GetValue(int index)
		{
			return m_values[index];
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public TValue Generate()
		{
			int index = WeightedDistribution.Generate(m_iidGenerator, m_weights, m_sum, m_count);
			return m_values[index];
		}
	}
}
