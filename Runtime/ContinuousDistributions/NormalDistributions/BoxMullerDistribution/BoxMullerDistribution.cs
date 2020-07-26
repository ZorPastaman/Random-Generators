// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Box-Muller distribution algorithms.
	/// </summary>
	public static class BoxMullerDistribution
	{
		public const float DefaultMean = 0f;
		public const float DefaultDeviation = 1f;

		private const float TwoPI = Mathf.PI * 2f;

		private static readonly float s_epsilon = Mathf.Epsilon;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate()
		{
			float u1;
			do
			{
				u1 = Random.value;
			} while (u1 <= s_epsilon);

			float u2 = Random.value;

			return Compute(u1, u2);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate(float mean, float deviation)
		{
			(float z0, float z1) = Generate();
			return Modify(z0, z1, mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate([NotNull] Func<float> iidFunc)
		{
			float u1;
			do
			{
				u1 = iidFunc();
			} while (u1 <= s_epsilon);

			float u2 = iidFunc();

			return Compute(u1, u2);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate([NotNull] Func<float> iidFunc, float mean, float deviation)
		{
			(float z0, float z1) = Generate(iidFunc);
			return Modify(z0, z1, mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate<T>([NotNull] T iidGenerator) where T : IContinuousGenerator
		{
			float u1;
			do
			{
				u1 = iidGenerator.Generate();
			} while (u1 <= s_epsilon);

			float u2 = iidGenerator.Generate();

			return Compute(u1, u2);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate<T>([NotNull] T iidGenerator, float mean, float deviation)
			where T : IContinuousGenerator
		{
			(float z0, float z1) = Generate(iidGenerator);
			return Modify(z0, z1, mean, deviation);
		}

		/// <summary>
		/// Computes generated values using <paramref name="u1"/> and <paramref name="u2"/> as iids.
		/// </summary>
		/// <param name="u1">Iid in range [0, 1].</param>
		/// <param name="u2">Iid in range [0, 1].</param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static (float, float) Compute(float u1, float u2)
		{
			float sqrt = Mathf.Sqrt(-2f * Mathf.Log(u1));
			float cos = Mathf.Cos(TwoPI * u2);
			float sin = Mathf.Sign(cos) * Mathf.Sqrt(1f - cos * cos);

			float z0 = sqrt * cos;
			float z1 = sqrt * sin;

			return (z0, z1);
		}

		/// <summary>
		/// Modifies <paramref name="z0"/> and <paramref name="z1"/> in range [0, 1]
		/// so that the distribution corresponds its <paramref name="mean"/> and <paramref name="deviation"/>.
		/// </summary>
		/// <returns>
		/// Two modified generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static (float, float) Modify(float z0, float z1, float mean, float deviation)
		{
			return (z0 * deviation + mean, z1 * deviation + mean);
		}
	}
}
