// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Irwin-Hall distribution algorithms.
	/// </summary>
	public static class IrwinHallDistribution
	{
		public const float DefaultStartPoint = 0f;
		/// <summary>
		/// How many independent and identically distributed random variables are generated by default.
		/// </summary>
		public const byte DefaultIids = 10;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[Pure]
		public static float Generate(byte iids = DefaultIids)
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += Random.value;
			}

			return random;
		}

		/// <summary>
		/// Generates a random value using the specified parameters and <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="iids"/>].
		/// </returns>
		[Pure]
		public static float Generate(float startPoint, byte iids = DefaultIids)
		{
			return Modify(Generate(iids), startPoint);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc, byte iids = DefaultIids)
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += iidFunc();
			}

			return random;
		}

		/// <summary>
		/// Generates a random value using the specified parameters and <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid in range [0, 1] source.</param>
		/// <param name="startPoint"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="iids"/>].
		/// </returns>
		[Pure]
		public static float Generate([NotNull] Func<float> iidFunc, float startPoint, byte iids = DefaultIids)
		{
			return Modify(Generate(iidFunc, iids), startPoint);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>Generated value in range [0, <paramref name="iids"/>].</returns>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, byte iids = DefaultIids)
			where T : IContinuousGenerator
		{
			float random = 0f;

			for (byte i = 0; i < iids; ++i)
			{
				random += iidGenerator.Generate();
			}

			return random;
		}

		/// <summary>
		/// Generates a random value using the specified parameters
		/// and <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid in range [0, 1] source.</param>
		/// <param name="startPoint"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		/// <returns>
		/// Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="iids"/>].
		/// </returns>
		[Pure]
		public static float Generate<T>([NotNull] T iidGenerator, float startPoint, byte iids = DefaultIids)
			where T : IContinuousGenerator
		{
			return Modify(Generate(iidGenerator, iids), startPoint);
		}

		/// <summary>
		/// Modifies <paramref name="generated"/> in range [0, n] so that the distribution corresponds its
		/// <paramref name="startPoint"/>.
		/// </summary>
		/// <param name="generated">Generated value in range [0, n]</param>
		/// <param name="startPoint"></param>
		/// <returns>
		/// Modified generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + n].
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float Modify(float generated, float startPoint)
		{
			return generated + startPoint;
		}
	}
}
