// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

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
		public const int DefaultStartPoint = 0;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float lambda)
		{
			return GenerateByUnity(ComputeE(lambda));
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float lambda, int startPoint)
		{
			return Generate(lambda) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup)
		{
			return GenerateByUnity(setup.e);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup, int startPoint)
		{
			return Generate(setup) + startPoint;
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
			return GenerateByFunc(iidFunc, ComputeE(lambda));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float lambda, int startPoint)
		{
			return Generate(iidFunc, lambda) + startPoint;
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
			return GenerateByFunc(iidFunc, setup.e);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup, int startPoint)
		{
			return Generate(iidFunc, setup) + startPoint;
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
			return GenerateByGenerator(iidGenerator, ComputeE(lambda));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float lambda, int startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, lambda) + startPoint;
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
			return GenerateByGenerator(iidGenerator, setup.e);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <param name="startPoint"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup, int startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, setup) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="e">Computed in <see cref="ComputeE"/> value.</param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static int GenerateByUnity(float e)
		{
			int x = 0;
			float p = 1f;

			do
			{
				++x;
				p *= Random.value;
			} while (p > e);

			return x - 1;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc"></param>
		/// <param name="e">Computed in <see cref="ComputeE"/> value.</param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static int GenerateByFunc([NotNull] Func<float> iidFunc, float e)
		{
			int x = 0;
			float p = 1f;

			do
			{
				++x;
				p *= iidFunc();
			} while (p > e);

			return x - 1;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator"></param>
		/// <param name="e">Computed in <see cref="ComputeE"/> value.</param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static int GenerateByGenerator<T>([NotNull] T iidGenerator, float e) where T : IContinuousGenerator
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
