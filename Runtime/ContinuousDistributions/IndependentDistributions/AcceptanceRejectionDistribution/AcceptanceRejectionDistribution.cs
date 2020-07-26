// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.IndependentDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Acceptance-Rejection distribution algorithms.
	/// </summary>
	public static class AcceptanceRejectionDistribution
	{
		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function
		/// and <see cref="Random.value"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value in range [0, 1] and y is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] AnimationCurve probabilityCurve)
		{
			float value;

			do
			{
				value = Random.value;
			} while (Random.value > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function
		/// and <see cref="Random.Range(float,float)"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value in range [<paramref name="min"/>, <paramref name="max"/>]
		/// and y is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] AnimationCurve probabilityCurve, float min, float max)
		{
			float value;

			do
			{
				value = Random.Range(min, max);
			} while (Random.value > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function
		/// and <see cref="Random.value"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityFunc">
		/// Probability function where the argument is a random value in range [0, 1]
		/// and the result is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float, float> probabilityFunc)
		{
			float value;

			do
			{
				value = Random.value;
			} while (Random.value > probabilityFunc(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function
		/// and <see cref="Random.Range(float,float)"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityFunc">
		/// Probability function where the argument is a random value in range
		/// [<paramref name="min"/>, <paramref name="max"/>] and the result is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float, float> probabilityFunc, float min, float max)
		{
			float value;

			do
			{
				value = Random.Range(min, max);
			} while (Random.value > probabilityFunc(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function
		/// and <paramref name="valueFunc"/> as a generated value source.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityCurve">
		/// Probability function where the x is a random value and y is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] AnimationCurve probabilityCurve)
		{
			float value;

			do
			{
				value = valueFunc();
			} while (Random.value > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function,
		/// <paramref name="valueFunc"/> as a generated value source
		/// and <paramref name="checkFunc"/> as a check value source.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="checkFunc">Check value source.</param>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value and y is its probability.
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with max probability
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float> checkFunc,
			[NotNull] AnimationCurve probabilityCurve)
		{
			float value;

			do
			{
				value = valueFunc();
			} while (checkFunc() > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function,
		/// and <paramref name="valueFunc"/> as a generated value source.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// Probability function where the argument is a random value and the result is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float, float> probabilityFunc)
		{
			float value;

			do
			{
				value = valueFunc();
			} while (Random.value > probabilityFunc(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function,
		/// <paramref name="valueFunc"/> as a generated value source
		/// and <paramref name="checkFunc"/> as a check value source.
		/// </summary>
		/// <param name="valueFunc">Generated value source.</param>
		/// <param name="checkFunc">Check value source.</param>
		/// <param name="probabilityFunc">
		/// Probability function where the argument is a random value and the result is its probability.
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with max probability
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float> checkFunc,
			[NotNull] Func<float, float> probabilityFunc)
		{
			float value;

			do
			{
				value = valueFunc();
			} while (checkFunc() > probabilityFunc(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function,
		/// <paramref name="valueGenerator"/> as a generated value source.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value and y is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T valueGenerator, [NotNull] AnimationCurve probabilityCurve)
			where T : IContinuousGenerator
		{
			float value;

			do
			{
				value = valueGenerator.Generate();
			} while (Random.value > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function,
		/// <paramref name="valueGenerator"/> as a generated value source
		/// and <paramref name="checkGenerator"/> as a check value source.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value and y is its probability.
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with max probability
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate<TValue, TCheck>([NotNull] TValue valueGenerator, [NotNull] TCheck checkGenerator,
			[NotNull] AnimationCurve probabilityCurve)
			where TValue : IContinuousGenerator where TCheck : IContinuousGenerator
		{
			float value;

			do
			{
				value = valueGenerator.Generate();
			} while (checkGenerator.Generate() > probabilityCurve.Evaluate(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function,
		/// <paramref name="valueGenerator"/> as a generated value source.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="probabilityFunc">
		/// Probability function where x is a random value and y is its probability.
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with max probability
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T valueGenerator, [NotNull] Func<float, float> probabilityFunc)
			where T : IContinuousGenerator
		{
			float value;

			do
			{
				value = valueGenerator.Generate();
			} while (Random.value > probabilityFunc(value));

			return value;
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function,
		/// <paramref name="valueGenerator"/> as a generated value source
		/// and <paramref name="checkGenerator"/> as a check value source.
		/// </summary>
		/// <param name="valueGenerator">Generated value source.</param>
		/// <param name="checkGenerator">Check value source.</param>
		/// <param name="probabilityFunc">
		/// Probability function where x is a random value and y is its probability.
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with max probability
		/// to avoid too many loop cycles.
		/// </remarks>
		[Pure]
		public static float Generate<TValue, TCheck>([NotNull] TValue valueGenerator, [NotNull] TCheck checkGenerator,
			[NotNull] Func<float, float> probabilityFunc)
			where TValue : IContinuousGenerator where TCheck : IContinuousGenerator
		{
			float value;

			do
			{
				value = valueGenerator.Generate();
			} while (checkGenerator.Generate() > probabilityFunc(value));

			return value;
		}
	}
}
