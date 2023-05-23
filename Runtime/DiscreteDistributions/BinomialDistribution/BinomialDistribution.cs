// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Binomial distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Section X.4.3 is used here.
	/// </remarks>
	public static class BinomialDistribution
	{
		public const float DefaultProbability = 0.5f;
		public const byte DefaultUpperBound = 10;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float probability, byte upperBound)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, probability, upperBound);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup, byte upperBound)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, setup, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte upperBound)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), probability, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup, byte upperBound)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), setup, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, ComputeQ(probability), upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup, byte upperBound)
			where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, setup.q, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="q">Computed in <see cref="ComputeQ"/> value.</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static int GenerateInternal<T>([NotNull] T iidGenerator, float q, byte upperBound)
			where T : IContinuousGenerator
		{
			int x = 0;
			float sum = 0f;

			do
			{
				float iid = 1f - iidGenerator.Generate();
				float e = -Mathf.Log(iid);
				sum += e / (upperBound - x++);
			} while (sum <= q);

			return x - 1;
		}

		/// <summary>
		/// Computes a negative logarithm of 1 - <paramref name="probability"/>.
		/// The result is used in generate methods.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float ComputeQ(float probability)
		{
			return -Mathf.Log(1f - probability);
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="BinomialDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change probability, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly float q;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="BinomialDistribution"/>.
			/// </summary>
			/// <param name="probability">True threshold in range [0, 1).</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float probability)
			{
				q = ComputeQ(probability);
			}
		}
	}
}
