// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	public static class MarsagliaDistribution
	{
		public const float DefaultMean = 0f;
		public const float DefaultDeviation = 1f;

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

		public static (float, float) Generate(float mean, float deviation)
		{
			(float z0, float z1) = Generate();
			return Modify(z0, z1, mean, deviation);
		}

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

		public static (float, float) Generate([NotNull] Func<float> iidFunc, float mean, float deviation)
		{
			(float z0, float z1) = Generate(iidFunc);
			return Modify(z0, z1, mean, deviation);
		}

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

		public static (float, float) Generate<T>([NotNull] T iidGenerator, float mean, float deviation)
			where T : IContinuousRandomGenerator
		{
			(float z0, float z1) = Generate(iidGenerator);
			return Modify(z0, z1, mean, deviation);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static (float, float) Modify(float z0, float z1, float mean, float deviation)
		{
			return (z0 * deviation + mean, z1 * deviation + mean);
		}
	}
}
