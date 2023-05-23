// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Irwin-Hall distribution algorithms.
	/// </summary>
	public static class IrwinHallDistribution
	{
		/// <summary>
		/// How many independent and identically distributed random values are generated by default.
		/// </summary>
		public const byte DefaultIids = 10;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultInclusive"/> as an iid source.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random values are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate(byte iids)
		{
			return Generate(UnityGeneratorStruct.DefaultInclusive, iids);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random values are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static float Generate([NotNull] Func<float> iidFunc, byte iids)
		{
			return Generate(new FuncGeneratorStruct(iidFunc), iids);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random values are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, byte iids) where T : IContinuousGenerator
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += iidGenerator.Generate();
			}

			return random;
		}
	}
}
