// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Poisson distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Section X.3.3 is used here.
	/// </remarks>
	public static class PoissonDistribution
	{
		public const float DefaultLambda = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultInclusive"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float lambda)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive, lambda);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultInclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive, setup);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float lambda)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), setup);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, ComputeE(lambda));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup) where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, setup.e);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator"></param>
		/// <param name="e">Computed in <see cref="ComputeE"/> value.</param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static int GenerateInternal<T>([NotNull] T iidGenerator, float e) where T : IContinuousGenerator
		{
			int x = 0;
			float p = 1f;

			do
			{
				++x;
				p *= iidGenerator.Generate();
			} while (p > e);

			return x - 1;
		}

		/// <summary>
		/// Computes e raised to the power of negative <paramref name="lambda"/>.
		/// The result is used in generate methods.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>E raised to the power of negative <paramref name="lambda"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float ComputeE(float lambda)
		{
			return Mathf.Exp(-lambda);
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="PoissonDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change lambda, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly float e;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="PoissonDistribution"/>.
			/// </summary>
			/// <param name="lambda"></param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float lambda)
			{
				e = ComputeE(lambda);
			}
		}
	}
}
