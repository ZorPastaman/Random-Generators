// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Weighted distribution algorithms.
	/// </summary>
	public static class WeightedDistribution
	{
		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		[Pure]
		public static int Generate([NotNull] uint[] weights)
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Generate(weights, sum, count);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <param name="sum">Sum of weights in <paramref name="weights"/>.</param>
		/// <param name="count">Count of <paramref name="weights"/>.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// <paramref name="count"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static int Generate([NotNull] uint[] weights, uint sum, int count)
		{
			return Pop(weights, sum, count, Random.value);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="weights">Weights array.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, [NotNull] uint[] weights)
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Generate(iidFunc, weights, sum, count);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="weights">Weights array.</param>
		/// <param name="sum">Sum of weights in <paramref name="weights"/>.</param>
		/// <param name="count">Count of <paramref name="weights"/>.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// <paramref name="count"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, [NotNull] uint[] weights, uint sum, int count)
		{
			return Pop(weights, sum, count, iidFunc());
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="weights">Weights array.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, [NotNull] uint[] weights)
			where T : IContinuousGenerator
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Generate(iidGenerator, weights, sum, count);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="weights">Weights array.</param>
		/// <param name="sum">Sum of weights in <paramref name="weights"/>.</param>
		/// <param name="count">Count of <paramref name="weights"/>.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// <paramref name="count"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, [NotNull] uint[] weights, uint sum, int count)
			where T : IContinuousGenerator
		{
			return Pop(weights, sum, count, iidGenerator.Generate());
		}

		/// <summary>
		/// Computes sum of first <paramref name="count"/> elements of <paramref name="weights"/>.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <param name="count">How many first elements are summed.</param>
		/// <returns>Computed sum.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static uint ComputeSum([NotNull] uint[] weights, int count)
		{
			uint sum = 0;

			for (int i = 0; i < count; ++i)
			{
				sum += weights[i];
			}

			return sum;
		}

		/// <summary>
		/// Pops index of <paramref name="weights"/> that corresponds to <paramref name="iid"/>.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <param name="sum">Sum of weights in <paramref name="weights"/>.</param>
		/// <param name="count">Count of <paramref name="weights"/>.</param>
		/// <param name="iid">Iid in range [0, 1].</param>
		/// <returns>Index of popped value.</returns>
		/// <remarks>
		/// <paramref name="count"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static int Pop([NotNull] uint[] weights, uint sum, int count, float iid)
		{
			uint random = (uint)(iid * sum);
			sum = 0;
			int i = 0;

			for (; i < count && sum <= random; ++i)
			{
				sum += weights[i];
			}

			return i - 1;
		}
	}
}
