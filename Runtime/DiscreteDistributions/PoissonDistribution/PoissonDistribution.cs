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
	public static class PoissonDistribution
	{
		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		[Pure]
		public static uint Generate(float lambda)
		{
			return Pop(Random.value, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid source.</param>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="iidFunc"/> must return independent and identically distributed random variable
		/// in range [0, 1].
		/// </remarks>
		[Pure]
		public static uint Generate([NotNull] Func<float> iidFunc, float lambda)
		{
			return Pop(iidFunc(), lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid source.</param>
		/// <param name="lambda"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="iidGenerator"/> must return independent and identically distributed random variable
		/// in range [0, 1].
		/// </remarks>
		[Pure]
		public static uint Generate<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			return Pop(iidGenerator.Generate(), lambda);
		}

		/// <summary>
		/// Pops a value that corresponds to <paramref name="u"/>.
		/// </summary>
		/// <param name="u">Iid in range [0, 1].</param>
		/// <param name="lambda"></param>
		/// <returns>Popped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static uint Pop(float u, float lambda)
		{
			uint x = 0;
			float p = Mathf.Exp(-lambda);
			float s = p;

			while (u > s)
			{
				++x;
				p *= lambda / x;
				s += p;
			}

			return x;
		}
	}
}
