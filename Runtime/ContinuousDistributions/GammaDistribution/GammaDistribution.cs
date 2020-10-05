// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

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
		public const float DefaultStartPoint = 0f;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate(float alpha, float beta)
		{
			bool alphaChanged = false;

			if (alpha < 1f)
			{
				alpha += 1f;
				alphaChanged = true;
			}

			float d = alpha - 1f / 3f;
			float c = 1f / Mathf.Sqrt(9f * d);

			float x;
			float v;
			float u;

			var normalDistributionWrapper = new NormalDistributionWrapper();

			do
			{
				do
				{
					x = normalDistributionWrapper.Generate();
					v = 1f + c * x;
				} while (v <= 0f);

				v = v * v * v;
				u = Random.value;
			} while (u >= 1f - 0.0331f * x * x * x * x ||
				Mathf.Log(u) >= 0.5f * x * x + d * (1f - v + Mathf.Log(v)));

			float result = d * v * beta;

			if (alphaChanged)
			{
				do
				{
					u = Random.value;
				} while (u <= 0f);

				result *= Mathf.Pow(u, 1f / (alpha - 1f));
			}

			return result;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(float alpha, float beta, float startPoint)
		{
			return Generate(alpha, beta) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float alpha, float beta)
		{
			bool alphaChanged = false;

			if (alpha < 1f)
			{
				alpha += 1f;
				alphaChanged = true;
			}

			float d = alpha - 1f / 3f;
			float c = 1f / Mathf.Sqrt(9f * d);

			float x;
			float v;
			float u;

			var normalDistributionWrapper = new NormalDistributionWrapper();

			do
			{
				do
				{
					x = normalDistributionWrapper.Generate(iidFunc);
					v = 1f + c * x;
				} while (v <= 0f);

				v = v * v * v;
				u = iidFunc();
			} while (u >= 1f - 0.0331f * x * x * x * x ||
				Mathf.Log(u) >= 0.5f * x * x + d * (1f - v + Mathf.Log(v)));

			float result = d * v * beta;

			if (alphaChanged)
			{
				do
				{
					u = iidFunc();
				} while (u <= 0f);

				result *= Mathf.Pow(u, 1f / (alpha - 1f));
			}

			return result;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float alpha, float beta, float startPoint)
		{
			return Generate(iidFunc, alpha, beta) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float alpha, float beta)
			where T : IContinuousGenerator
		{
			bool alphaChanged = false;

			if (alpha < 1f)
			{
				alpha += 1f;
				alphaChanged = true;
			}

			float d = alpha - 1f / 3f;
			float c = 1f / Mathf.Sqrt(9f * d);

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
				} while (v <= 0f);

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
				} while (u <= 0f);

				result *= Mathf.Pow(u, 1f / (alpha - 1f));
			}

			return result;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <param name="startPoint"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float alpha, float beta, float startPoint)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, alpha, beta) + startPoint;
		}

		/// <summary>
		/// Wrapper for normal distribution generator to use a second generated value.
		/// </summary>
		private struct NormalDistributionWrapper
		{
			private float m_spared;
			private bool m_hasShared;

			public float Generate()
			{
				if (m_hasShared)
				{
					m_hasShared = false;
					return m_spared;
				}

				float answer;
				(answer, m_spared) = NormalDistribution.Generate();
				m_hasShared = true;

				return answer;
			}

			public float Generate([NotNull] Func<float> iidFunc)
			{
				if (m_hasShared)
				{
					m_hasShared = false;
					return m_spared;
				}

				float answer;
				(answer, m_spared) = NormalDistribution.Generate(iidFunc);
				m_hasShared = true;

				return answer;
			}

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
