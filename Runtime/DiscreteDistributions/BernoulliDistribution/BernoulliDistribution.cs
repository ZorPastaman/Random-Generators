// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Bernoulli distribution algorithms.
	/// </summary>
	public static class BernoulliDistribution
	{
		public const float DefaultProbability = 0.5f;

		/// <summary>
		/// Generates a random value using <see cref="Random.Range(float,float)"/> in range [0, 1) as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool Generate(float probability)
		{
			return Random.Range(0f, NumberConstants.SubOne) < probability;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <returns>Generated value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool Generate([NotNull] Func<float> iidFunc, float probability)
		{
			return iidFunc() < probability;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <returns>Generated value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool Generate<T>([NotNull] T iidGenerator, float probability) where T : IContinuousGenerator
		{
			return iidGenerator.Generate() < probability;
		}
	}
}
