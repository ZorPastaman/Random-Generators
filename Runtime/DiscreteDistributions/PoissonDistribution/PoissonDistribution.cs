// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Section X.3.4 is used here.
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
		[Pure]
		public static int Generate(float lambda)
		{
			int x = 0;
			float p = 1f;
			float e = Mathf.Exp(-lambda);

			do
			{
				++x;
				p *= Random.value;
			} while (p > e);

			return x - 1;
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
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float lambda)
		{
			int x = 0;
			float p = 1f;
			float e = Mathf.Exp(-lambda);

			do
			{
				++x;
				p *= iidFunc();
			} while (p > e);

			return x - 1;
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
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			int x = 0;
			float p = 1f;
			float e = Mathf.Exp(-lambda);

			do
			{
				++x;
				p *= iidGenerator.Generate();
			} while (p > e);

			return x - 1;
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
	}
}
