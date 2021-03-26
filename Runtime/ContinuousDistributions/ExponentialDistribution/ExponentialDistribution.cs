// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Exponential distribution algorithms.
	/// </summary>
	public static class ExponentialDistribution
	{
		public const float DefaultLambda = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float lambda)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float lambda)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="lambda"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			float iid = 1f - iidGenerator.Generate();
			return -Mathf.Log(iid) / lambda;
		}
	}
}
