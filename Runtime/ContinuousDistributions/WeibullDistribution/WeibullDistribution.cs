// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Weibull distribution algorithms.
	/// </summary>
	public static class WeibullDistribution
	{
		public const float DefaultAlpha = 1f;
		public const float DefaultBeta = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float alpha, float beta)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, alpha, beta);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float alpha, float beta)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), alpha, beta);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape. Must be non-zero.</param>
		/// <param name="beta">Scale.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float alpha, float beta)
			where T : IContinuousGenerator
		{
			float iid = 1f - iidGenerator.Generate();
			float power = 1f / alpha;

			return Mathf.Pow(-Mathf.Log(iid), power) * beta;
		}
	}
}
