// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Geometric distribution algorithms.
	/// </summary>
	public static class GeometricDistribution
	{
		public const float DefaultProbability = 0.5f;
		public const int DefaultStartPoint = 0;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[Pure]
		public static int Generate(float probability)
		{
			float iid;
			do
			{
				iid = Random.value;
			} while (iid < NumberConstants.NormalEpsilon);

			return Mathf.FloorToInt(Mathf.Log(iid) / Mathf.Log(1f - probability));
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float probability, int startPoint)
		{
			return Generate(probability) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability)
		{
			float iid;
			do
			{
				iid = iidFunc();
			} while (iid < NumberConstants.NormalEpsilon);

			return Mathf.FloorToInt(Mathf.Log(iid) / Mathf.Log(1f - probability));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, int startPoint)
		{
			return Generate(iidFunc, probability) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Generated value.</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability) where T : IContinuousGenerator
		{
			float iid;
			do
			{
				iid = iidGenerator.Generate();
			} while (iid < NumberConstants.NormalEpsilon);

			return Mathf.FloorToInt(Mathf.Log(iid) / Mathf.Log(1f - probability));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, int startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, probability) + startPoint;
		}
	}
}
