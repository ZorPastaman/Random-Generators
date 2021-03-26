// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Gamma distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from George Marsaglia, Wai Wan Tsang (2000) "A Simple Method for Generating Gamma Variables"
	/// is used here.
	/// </remarks>
	public static class GammaDistribution
	{
		public const float DefaultAlpha = 1f;
		public const float DefaultBeta = 1f;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float alpha, float beta)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, alpha, beta);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(Setup setup, float beta)
		{
			return Generate(UnityGeneratorStruct.DefaultExclusive, setup, beta);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float alpha, float beta)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), alpha, beta);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, Setup setup, float beta)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), setup, beta);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float alpha, float beta)
			where T : IContinuousGenerator
		{
			float power;
			bool alphaChanged;
			(power, alpha, alphaChanged) = ComputeAlpha(alpha);
			(float c, float d) = ComputeCD(alpha);

			return Generate(iidGenerator, c, d, beta, power, alphaChanged);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T iidGenerator, Setup setup, float beta)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, setup.c, setup.d, beta, setup.power, setup.alphaChanged);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="c"></param>
		/// <param name="d"></param>
		/// <param name="beta"></param>
		/// <param name="power">
		/// Power used when <paramref name="alphaChanged"/> is <see langword="true"/> to transform the result.
		/// </param>
		/// <param name="alphaChanged">If original alpha was less than 1, this must be <see langword="true"/>.</param>
		/// <returns>Generated value.</returns>
		[Pure]
		private static float Generate<T>([NotNull] T iidGenerator, float c, float d, float beta,
			float power, bool alphaChanged) where T : IContinuousGenerator
		{
			float x;
			float v;
			float u;

			var normalDistributionWrapper = new NormalDistributionWrapper();

			do
			{
				do
				{
					x = normalDistributionWrapper.Generate(iidGenerator);
					v = 1f + c * x;
				} while (v < NumberConstants.NormalEpsilon);

				v = v * v * v;
				u = iidGenerator.Generate();
			} while (u >= 1f - 0.0331f * x * x * x * x ||
				Mathf.Log(u) >= 0.5f * x * x + d * (1f - v + Mathf.Log(v)));

			float result = d * v * beta;

			if (alphaChanged)
			{
				do
				{
					u = iidGenerator.Generate();
				} while (u < NumberConstants.NormalEpsilon);

				result *= Mathf.Pow(u, power);
			}

			return result;
		}

		/// <summary>
		/// Computes alpha for algorithm.
		/// </summary>
		/// <param name="alpha"></param>
		/// <returns>
		/// <para>
		/// <paramref name="alpha"/> + 1 and <see langword="true"/> if <paramref name="alpha"/> is less than 1.
		/// </para>
		/// <para>Original <paramref name="alpha"/> and <see langword="false"/> otherwise.</para>
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static unsafe (float power, float alpha, bool alphaChanged) ComputeAlpha(float alpha)
		{
			float power = 1f / alpha;
			bool alphaChanged = alpha < 1f;
			alpha += *(byte*)&alphaChanged;

			return (power, alpha, alphaChanged);
		}

		/// <summary>
		/// Computes c and d.
		/// </summary>
		/// <param name="alpha">Alpha that is used in algorithms.</param>
		/// <returns>c and d.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static (float c, float d) ComputeCD(float alpha)
		{
			float d = alpha - 1f / 3f;
			float c = 1f / Mathf.Sqrt(9f * d);

			return (c, d);
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="GammaDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change alpha, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly float d;
			public readonly float c;
			public readonly float power;
			public readonly bool alphaChanged;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="GammaDistribution"/>.
			/// </summary>
			/// <param name="alpha">Shape. Must be greater than 0.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float alpha)
			{
				(power, alpha, alphaChanged) = ComputeAlpha(alpha);
				(c, d) = ComputeCD(alpha);
			}
		}

		/// <summary>
		/// Wrapper for normal distribution generator to use a second generated value.
		/// </summary>
		private struct NormalDistributionWrapper
		{
			private float m_spared;
			private bool m_hasShared;

			[Pure]
			public float Generate<T>([NotNull] T iidGenerator) where T : IContinuousGenerator
			{
				if (m_hasShared)
				{
					m_hasShared = false;
					return m_spared;
				}

				float answer;
				(answer, m_spared) = NormalDistribution.Generate(iidGenerator);
				m_hasShared = true;

				return answer;
			}
		}
	}
}
