// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Extreme value distribution algorithms.
	/// </summary>
	public static class ExtremeValueDistribution
	{
		public const float DefaultLocation = 0f;
		public const float DefaultScale = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="location">Location.</param>
		/// <param name="scale">Scale. Must be more than 0.</param>
		/// <returns>Generated value.</returns>
		/// <remarks><paramref name="scale"/> must be more than 0.</remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float location, float scale)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, location, scale);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="location">Location.</param>
		/// <param name="scale">Scale. Must be more than 0.</param>
		/// <returns>Generated value.</returns>
		/// <remarks><paramref name="scale"/> must be more than 0.</remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float location, float scale)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), location, scale);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="location">Location.</param>
		/// <param name="scale">Scale. Must be more than 0.</param>
		/// <returns>Generated value.</returns>
		/// <remarks><paramref name="scale"/> must be more than 0.</remarks>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float location, float scale)
			where T : IContinuousGenerator
		{
			float iid = 1f - iidGenerator.Generate();
			return location - scale * Mathf.Log(-Mathf.Log(iid));
		}
	}
}
