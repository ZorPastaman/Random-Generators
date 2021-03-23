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

			return ComputeResult(iid, ComputeLambda(probability));
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
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[Pure]
		public static int Generate(Setup setup)
		{
			float iid;
			do
			{
				iid = Random.value;
			} while (iid < NumberConstants.NormalEpsilon);

			return ComputeResult(iid, setup.lambda);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="setup">.</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup, int startPoint)
		{
			return Generate(setup) + startPoint;
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

			return ComputeResult(iid, ComputeLambda(probability));
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
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup)
		{
			float iid;
			do
			{
				iid = iidFunc();
			} while (iid < NumberConstants.NormalEpsilon);

			return ComputeResult(iid, setup.lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup, int startPoint)
		{
			return Generate(iidFunc, setup) + startPoint;
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

			return ComputeResult(iid, ComputeLambda(probability));
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

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup) where T : IContinuousGenerator
		{
			float iid;
			do
			{
				iid = iidGenerator.Generate();
			} while (iid < NumberConstants.NormalEpsilon);

			return ComputeResult(iid, setup.lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="setup"></param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup, int startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, setup) + startPoint;
		}

		/// <summary>
		/// Computes the natural logarithm of 1 - <paramref name="probability"/>.
		/// The result is used in generate methods.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1).</param>
		/// <returns>Natural logarithm of 1 - <paramref name="probability"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float ComputeLambda(float probability)
		{
			return Mathf.Log(1f - probability);
		}

		/// <summary>
		/// Computes the result of Geometric distribution.
		/// </summary>
		/// <param name="iid">
		/// Independent and identically distributed random value in range (0, 1].
		/// </param>
		/// <param name="lambda">Lambda. Must be greater than 0.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static int ComputeResult(float iid, float lambda)
		{
			return Mathf.FloorToInt(Mathf.Log(iid) / lambda);
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="GeometricDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change probability, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly float lambda;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="PoissonDistribution"/>.
			/// </summary>
			/// <param name="probability">Probability. Must be greater than 0 and less than 1.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float probability)
			{
				lambda = ComputeLambda(probability);
			}
		}
	}
}
