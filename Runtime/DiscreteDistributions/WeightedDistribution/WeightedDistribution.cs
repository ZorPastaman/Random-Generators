// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		/// <remarks>
		/// Count of <paramref name="weights"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] uint[] weights)
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Pop(weights, sum, count, Random.value);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <param name="setup">Precomputed data.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] uint[] weights, Setup setup)
		{
			return Pop(weights, setup.sum, setup.count, Random.value);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="weights">Weights array.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// Count of <paramref name="weights"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, [NotNull] uint[] weights)
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Pop(weights, sum, count, iidFunc());
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="weights">Weights array.</param>
		/// <param name="setup">Precomputed data.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, [NotNull] uint[] weights, Setup setup)
		{
			return Pop(weights, setup.sum, setup.count, iidFunc());
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="weights">Weights array.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// Count of <paramref name="weights"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, [NotNull] uint[] weights)
			where T : IContinuousGenerator
		{
			int count = weights.Length;
			uint sum = ComputeSum(weights, count);

			return Pop(weights, sum, count, iidGenerator.Generate());
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="weights">Weights array.</param>
		/// <param name="setup">Precomputed data.</param>
		/// <returns>Index of a gotten value from <paramref name="weights"/>.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, [NotNull] uint[] weights, Setup setup)
			where T : IContinuousGenerator
		{
			return Pop(weights, setup.sum, setup.count, iidGenerator.Generate());
		}

		/// <summary>
		/// Computes sum of first <paramref name="count"/> elements of <paramref name="weights"/>.
		/// </summary>
		/// <param name="weights">Weights array.</param>
		/// <param name="count">How many first elements are summed.</param>
		/// <returns>Computed sum.</returns>
		[Pure]
		private static uint ComputeSum([NotNull] uint[] weights, int count)
		{
			uint sum = 0u;

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
		[Pure]
		private static int Pop([NotNull] uint[] weights, uint sum, int count, float iid)
		{
			uint random = (uint)(iid * sum);
			sum = 0u;
			int i = 0;

			for (; sum <= random & i < count; ++i)
			{
				sum += weights[i];
			}

			return i - 1;
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="WeightedDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change weights, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly uint sum;
			public readonly int count;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="WeightedDistribution"/>.
			/// </summary>
			/// <param name="weights">Weights array. Its count must be greater than 0.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup([NotNull] uint[] weights)
			{
				count = weights.Length;
				sum = ComputeSum(weights, count);
			}
		}
	}
}
