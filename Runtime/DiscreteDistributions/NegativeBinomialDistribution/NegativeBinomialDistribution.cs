// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Negative Binomial distribution algorithms.
	/// </summary>
	public static unsafe class NegativeBinomialDistribution
	{
		public const int DefaultStartPoint = 0;
		public const float DefaultProbability = 0.5f;
		public const byte DefaultFailures = 3;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate(float probability, byte failures)
		{
			if (probability <= 0f | failures == 0)
			{
				return 0;
			}

			int* failureSuccess = stackalloc int[2];

			do
			{
				bool success = Random.value <= probability;
				int index = *(byte*)&success;
				++failureSuccess[index];
			} while (failureSuccess[0] < failures);

			return failureSuccess[1];
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate(int startPoint, float probability, byte failures)
		{
			return Generate(probability, failures) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte failures)
		{
			if (probability <= 0f | failures == 0)
			{
				return 0;
			}

			int* failureSuccess = stackalloc int[2];

			do
			{
				bool success = iidFunc() <= probability;
				int index = *(byte*)&success;
				++failureSuccess[index];
			} while (failureSuccess[0] < failures);

			return failureSuccess[1];
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float probability, byte failures)
		{
			return Generate(iidFunc, probability, failures) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte failures)
			where T : IContinuousGenerator
		{
			if (probability <= 0f | failures == 0)
			{
				return 0;
			}

			int* failureSuccess = stackalloc int[2];

			do
			{
				bool success = iidGenerator.Generate() <= probability;
				int index = *(byte*)&success;
				++failureSuccess[index];
			} while (failureSuccess[0] < failures);

			return failureSuccess[1];
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="failures"></param>
		/// <returns>Generated value.</returns>
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float probability, byte failures)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, probability, failures) + startPoint;
		}
	}
}
