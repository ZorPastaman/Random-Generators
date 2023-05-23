// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Rejection distribution algorithms.
	/// </summary>
	public static class RejectionDistribution
	{
		public const float DefaultMin = 0f;
		public const float DefaultMax = 1f;

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function
		/// and <see cref="UnityGeneratorStruct.DefaultInclusive"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value in range [0, 1] and y is its probability in range [0, 1].
		/// </param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] AnimationCurve probabilityCurve)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive,
				UnityGeneratorStruct.DefaultInclusive, probabilityCurve);
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityCurve"/> as a probability function
		/// and <see cref="UnityGeneratorStruct"/> with <paramref name="min"/> and <paramref name="max"/>
		/// as a generated value source.
		/// </summary>
		/// <param name="probabilityCurve">
		/// Probability function where x is a random value in range [<paramref name="min"/>, <paramref name="max"/>]
		/// and y is its probability in range [0, 1].
		/// </param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityCurve"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] AnimationCurve probabilityCurve, float min, float max)
		{
			return Generate(new UnityGeneratorStruct(min, max),
				UnityGeneratorStruct.DefaultInclusive, probabilityCurve);
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function
		/// and <see cref="UnityGeneratorStruct.DefaultInclusive"/> as a generated value source.
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float, float> probabilityFunc)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive,
				UnityGeneratorStruct.DefaultInclusive, probabilityFunc);
		}

		/// <summary>
		/// Generates a random value using <paramref name="probabilityFunc"/> as a probability function
		/// and <see cref="UnityGeneratorStruct.DefaultInclusive"/>
		/// with <paramref name="min"/> and <paramref name="max"/> as a generated value source.
		/// </summary>
		/// <param name="probabilityFunc">
		/// Probability function where the argument is a random value in range
		/// [<paramref name="min"/>, <paramref name="max"/>] and the result is its probability in range [0, 1].
		/// </param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's recommended that <paramref name="probabilityFunc"/> has at least one point with probability 1
		/// to avoid too many loop cycles.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float, float> probabilityFunc, float min, float max)
		{
			return Generate(new UnityGeneratorStruct(min, max),
				UnityGeneratorStruct.DefaultInclusive, probabilityFunc);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] AnimationCurve probabilityCurve)
		{
			return Generate(new FuncGeneratorStruct(valueFunc),
				UnityGeneratorStruct.DefaultInclusive, probabilityCurve);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float> checkFunc,
			[NotNull] AnimationCurve probabilityCurve)
		{
			return Generate(new FuncGeneratorStruct(valueFunc),
				new FuncGeneratorStruct(checkFunc), probabilityCurve);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float, float> probabilityFunc)
		{
			return Generate(new FuncGeneratorStruct(valueFunc),
				UnityGeneratorStruct.DefaultInclusive, probabilityFunc);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> valueFunc, [NotNull] Func<float> checkFunc,
			[NotNull] Func<float, float> probabilityFunc)
		{
			return Generate(new FuncGeneratorStruct(valueFunc),
				new FuncGeneratorStruct(checkFunc), probabilityFunc);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T valueGenerator, [NotNull] AnimationCurve probabilityCurve)
			where T : IContinuousGenerator
		{
			return Generate(valueGenerator, UnityGeneratorStruct.DefaultInclusive, probabilityCurve);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate<T>([NotNull] T valueGenerator, [NotNull] Func<float, float> probabilityFunc)
			where T : IContinuousGenerator
		{
			return Generate(valueGenerator, UnityGeneratorStruct.DefaultInclusive, probabilityFunc);
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
