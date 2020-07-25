﻿// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Bates distribution algorithms.
	/// </summary>
	public static class BatesDistribution
	{
		public const float DefaultMean = 0.5f;
		public const float DefaultDeviation = 0.5f;
		/// <summary>
		/// How many independent and identically distributed random variables are generated by default.
		/// </summary>
		public const byte DefaultIids = 3;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range [0, 1].</returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate(byte iids = DefaultIids)
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += Random.value;
			}

			return random / iids;
		}


		/// <summary>
		/// Generates a random value using the specified parameters and <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range
		/// [<paramref name="mean"/> - <paramref name="deviation"/>,
		/// <paramref name="mean"/> + <paramref name="deviation"/>].
		/// </returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate(float mean, float deviation, byte iids = DefaultIids)
		{
			return Modify(Generate(iids), mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range [0, 1].</returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc, byte iids = DefaultIids)
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += iidFunc();
			}

			return random / iids;
		}

		/// <summary>
		/// Generates a random value using the specified parameters and <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range
		/// [<paramref name="mean"/> - <paramref name="deviation"/>,
		/// <paramref name="mean"/> + <paramref name="deviation"/>].
		/// </returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc,
			float mean, float deviation, byte iids = DefaultIids)
		{
			return Modify(Generate(iidFunc, iids), mean, deviation);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range [0, 1].
		/// </returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, byte iids = DefaultIids)
			where T : IContinuousRandomGenerator
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += iidGenerator.Generate();
			}

			return random / iids;
		}

		/// <summary>
		/// Generates a random value using the specified parameters
		/// and <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range
		/// [<paramref name="mean"/> - <paramref name="deviation"/>,
		/// <paramref name="mean"/> + <paramref name="deviation"/>].
		/// </returns>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float mean, float deviation, byte iids = DefaultIids)
			where T : IContinuousRandomGenerator
		{
			return Modify(Generate(iidGenerator, iids), mean, deviation);
		}

		/// <summary>
		/// Modifies <paramref name="generated"/> in range [0, 1] so that the distribution corresponds its
		/// <paramref name="mean"/> and <paramref name="deviation"/>.
		/// </summary>
		/// <param name="generated">Generated value in range [0, 1]</param>
		/// <returns>
		/// Modified generated value in range
		/// [<paramref name="mean"/> - <paramref name="deviation"/>,
		/// <paramref name="mean"/> + <paramref name="deviation"/>].
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float Modify(float generated, float mean, float deviation)
		{
			return (generated - DefaultMean) * (deviation / DefaultDeviation) + mean;
		}
	}
}
