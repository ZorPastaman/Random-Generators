// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Geometric distribution algorithms.
	/// </summary>
	public static class GeometricDistribution
	{
		public const float DefaultProbability = 0.5f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float probability)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, probability);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, setup);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), probability);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
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
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability) where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, ComputeLambda(probability));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup) where T : IContinuousGenerator
		{
			return GenerateInternal(iidGenerator, setup.lambda);
		}

		/// <summary>
		/// Generate the result of Geometric distribution.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda">Lambda. Must be greater than 0.</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static int GenerateInternal<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			float iid = 1f - iidGenerator.Generate();
			return Mathf.FloorToInt(Mathf.Log(iid) / lambda);
		}

		/// <summary>
		/// Computes the natural logarithm of 1 - <paramref name="probability"/>.
		/// The result is used in generate methods.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Natural logarithm of 1 - <paramref name="probability"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float ComputeLambda(float probability)
		{
			return Mathf.Log(1f - probability);
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="GeometricDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change probability, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly float lambda;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="PoissonDistribution"/>.
			/// </summary>
			/// <param name="probability">Probability. Must be greater than 0 and less than 1.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float probability)
			{
				lambda = ComputeLambda(probability);
			}
		}
	}
}
