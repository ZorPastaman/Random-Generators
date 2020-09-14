// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Binomial distribution algorithms.
	/// </summary>
	public static unsafe class BinomialDistribution
	{
		public const int DefaultStartPoint = 0;
		public const float DefaultProbability = 0.5f;
		public const byte DefaultUpperBound = 10;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate(float probability, byte upperBound)
		{
			int x = 0;

			if (probability <= 0f)
			{
				return x;
			}

			for (; upperBound > 0; --upperBound)
			{
				bool result = Random.value <= probability;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate(int startPoint, float probability, byte upperBound)
		{
			return Generate(probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid source in range [0, 1].</param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte upperBound)
		{
			int x = 0;

			if (probability <= 0f)
			{
				return x;
			}

			for (; upperBound > 0; --upperBound)
			{
				bool result = iidFunc() <= probability;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid source in range [0, 1].</param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float probability, byte upperBound)
		{
			return Generate(iidFunc, probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid source in range [0, 1].</param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			int x = 0;

			if (probability <= 0f)
			{
				return x;
			}

			for (; upperBound > 0; --upperBound)
			{
				bool result = iidGenerator.Generate() <= probability;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid source in range [0, 1].</param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, probability, upperBound) + startPoint;
		}
	}
}
