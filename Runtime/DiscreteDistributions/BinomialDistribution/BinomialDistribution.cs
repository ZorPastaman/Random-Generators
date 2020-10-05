// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Binomial distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Chapter X.4 is used here.
	/// </remarks>
	public static unsafe class BinomialDistribution
	{
		public const int DefaultStartPoint = 0;
		public const float DefaultProbability = 0.5f;
		public const byte DefaultUpperBound = 10;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float probability, byte upperBound)
		{
			return Pop(Random.value, probability, upperBound);
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(int startPoint, float probability, byte upperBound)
		{
			return Pop(Random.value, probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte upperBound)
		{
			return Pop(iidFunc(), probability, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float probability, byte upperBound)
		{
			return Pop(iidFunc(), probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range [0, <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			return Pop(iidGenerator.Generate(), probability, upperBound);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range [0, 1].</param>
		/// <param name="upperBound"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="upperBound"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float probability, byte upperBound)
			where T : IContinuousGenerator
		{
			return Pop(iidGenerator.Generate(), probability, upperBound) + startPoint;
		}

		/// <summary>
		/// Pops a value that corresponds to <paramref name="iid"/>.
		/// </summary>
		/// <param name="iid">Iid in range [0, 1].</param>
		/// <param name="probability"></param>
		/// <param name="upperBound"></param>
		/// <returns>Popped value.</returns>
		[Pure]
		private static int Pop(float iid, float probability, byte upperBound)
		{
			bool probabilityChanged = false;

			if (probability > 0.5f)
			{
				probability = 1f - probability;
				probabilityChanged = true;
			}

			int x = 0;
			float q = 1f - probability;

			for (byte i = 0; i < upperBound; ++i)
			{
				bool condition = iid > q;
				int b = *(byte*)&condition;
				iid = (iid - q * b) / (probability * b + q * (1 - b));
				x += b;
			}

			return probabilityChanged ? upperBound - x : x;
		}
	}
}
