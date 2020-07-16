// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Marsaglia distribution algorithms.
	/// </summary>
	public static class MarsagliaDistribution
	{
		public const float DefaultMean = 0f;
		public const float DefaultDeviation = 1f;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
		public static (float, float) Generate()
		{
			float u, v, s;

			do
			{
				u = Random.value * 2f - 1f;
				v = Random.value * 2f - 1f;
				s = u * u + v * v;
			} while (s >= 1f || s <= 0f);

			s = Mathf.Sqrt(-2f * Mathf.Log(s) / s);

			float z0 = u * s;
			float z1 = v * s;

			return (z0, z1);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
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
		public static (float, float) Generate([NotNull] Func<float> iidFunc)
		{
			float u, v, s;

			do
			{
				u = iidFunc() * 2f - 1f;
				v = iidFunc() * 2f - 1f;
				s = u * u + v * v;
			} while (s >= 1f || s <= 0f);

			s = Mathf.Sqrt(-2f * Mathf.Log(s) / s);

			float z0 = u * s;
			float z1 = v * s;

			return (z0, z1);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <returns>
		/// Two generated values.
		/// </returns>
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
		public static (float, float) Generate<T>([NotNull] T iidGenerator) where T : IContinuousRandomGenerator
		{
			float u, v, s;

			do
			{
				u = iidGenerator.Generate() * 2f - 1f;
				v = iidGenerator.Generate() * 2f - 1f;
				s = u * u + v * v;
			} while (s >= 1f || s <= 0f);

			s = Mathf.Sqrt(-2f * Mathf.Log(s) / s);

			float z0 = u * s;
			float z1 = v * s;

			return (z0, z1);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		public static (float, float) Generate<T>([NotNull] T iidGenerator, float mean, float deviation)
			where T : IContinuousRandomGenerator
		{
			(float z0, float z1) = Generate(iidGenerator);
			return Modify(z0, z1, mean, deviation);
		}

		/// <summary>
		/// Modifies <paramref name="z0"/> and <paramref name="z1"/> in range [0, 1]
		/// so that the distribution corresponds its <paramref name="mean"/> and <paramref name="deviation"/>.
		/// </summary>
		/// <returns>
		/// Two modified generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static (float, float) Modify(float z0, float z1, float mean, float deviation)
		{
			return (z0 * deviation + mean, z1 * deviation + mean);
		}
	}
}
