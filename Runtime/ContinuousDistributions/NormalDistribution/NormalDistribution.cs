// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Normal distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Marsaglia polar method is used here.
	/// </remarks>
	public static class NormalDistribution
	{
		public const float DefaultMean = 0f;
		public const float DefaultDeviation = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultInclusive"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static (float, float) Generate()
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultInclusive"/> as an iid source.
		/// </summary>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static (float, float) Generate(float mean, float deviation)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive, mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static (float, float) Generate([NotNull] Func<float> iidFunc)
		{
			return Generate(new FuncGeneratorStruct(iidFunc));
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static (float, float) Generate([NotNull] Func<float> iidFunc, float mean, float deviation)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[Pure]
		public static (float, float) Generate<T>([NotNull] T iidGenerator) where T : IContinuousGenerator
		{
			float u, v, s;

			do
			{
				u = iidGenerator.Generate() * 2f - 1f;
				v = iidGenerator.Generate() * 2f - 1f;
				s = u * u + v * v;
			} while (s >= 1f | s < NumberConstants.NormalEpsilon);

			s = Mathf.Sqrt(-2f * Mathf.Log(s) / s);

			float z0 = u * s;
			float z1 = v * s;

			return (z0, z1);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <returns>
		/// Two generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static (float, float) Generate<T>([NotNull] T iidGenerator, float mean, float deviation)
			where T : IContinuousGenerator
		{
			(float z0, float z1) = Generate(iidGenerator);
			return Modify(z0, z1, mean, deviation);
		}

		/// <summary>
		/// Modifies <paramref name="z0"/> and <paramref name="z1"/> in range [0, 1]
		/// so that the distribution corresponds its <paramref name="mean"/> and <paramref name="deviation"/>.
		/// </summary>
		/// <returns>
		/// Two modified generated values.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static (float, float) Modify(float z0, float z1, float mean, float deviation)
		{
			return (z0 * deviation + mean, z1 * deviation + mean);
		}
	}
}
