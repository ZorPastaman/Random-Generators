// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Exponential distribution algorithms.
	/// </summary>
	public static class ExponentialDistribution
	{
		public const float DefaultLambda = 1f;
		public const float DefaultStartPoint = 0f;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[Pure]
		public static float Generate(float lambda)
		{
			float iid;

			do
			{
				iid = Random.value;
			} while (iid < NumberConstants.NormalEpsilon);

			return -Mathf.Log(iid) / lambda;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float lambda, float startPoint)
		{
			return Generate(lambda) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float lambda)
		{
			float iid;

			do
			{
				iid = iidFunc();
			} while (iid < NumberConstants.NormalEpsilon);

			return -Mathf.Log(iid) / lambda;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float lambda, float startPoint)
		{
			return Generate(iidFunc, lambda) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float lambda) where T : IContinuousGenerator
		{
			float iid;

			do
			{
				iid = iidGenerator.Generate();
			} while (iid < NumberConstants.NormalEpsilon);

			return -Mathf.Log(iid) / lambda;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float lambda, float startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, lambda) + startPoint;
		}
	}
}
