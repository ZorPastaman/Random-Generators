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
	/// Collection of methods that generate a random value using Binomial distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Section X.4.3 is used here.
	/// </remarks>
	public static class BinomialDistribution
	{
		public const int DefaultStartPoint = 0;
		public const float DefaultProbability = 0.5f;
		public const byte DefaultUpperBound = 10;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate(float probability, byte upperBound)
		{
			float q = -Mathf.Log(1f - probability);
			float sum = 0f;
			int x = 0;

			do
			{
				float iid;
				do
				{
					iid = Random.value;
				} while (iid < NumberConstants.NormalEpsilon);

				float e = -Mathf.Log(iid);
				sum += e / (upperBound - x);
				++x;
			} while (sum <= q);

			return x - 1;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(int startPoint, float probability, byte upperBound)
		{
			return Generate(probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte upperBound)
		{
			float q = -Mathf.Log(1f - probability);
			float sum = 0f;
			int x = 0;

			do
			{
				float iid;
				do
				{
					iid = iidFunc();
				} while (iid < NumberConstants.NormalEpsilon);

				float e = -Mathf.Log(iid);
				sum += e / (upperBound - x);
				++x;
			} while (sum <= q);

			return x - 1;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float probability, byte upperBound)
		{
			return Generate(iidFunc, probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			float q = -Mathf.Log(1f - probability);
			float sum = 0f;
			int x = 0;

			do
			{
				float iid;
				do
				{
					iid = iidGenerator.Generate();
				} while (iid < NumberConstants.NormalEpsilon);

				float e = -Mathf.Log(iid);
				sum += e / (upperBound - x);
				++x;
			} while (sum <= q);

			return x - 1;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1).</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, probability, upperBound) + startPoint;
		}
	}
}
