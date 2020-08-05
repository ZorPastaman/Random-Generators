// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Binomial distribution algorithms.
	/// </summary>
	public static unsafe class BinomialDistribution
	{
		public const int DefaultStartPoint = 0;

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range [0, <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate(float p, byte n)
		{
			int x = 0;

			if (p <= 0f)
			{
				return x;
			}

			for (; n > 0; --n)
			{
				bool result = Random.value <= p;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <see cref="Random.value"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate(int startPoint, float p, byte n)
		{
			return Generate(p, n) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid source in range [0, 1].</param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range [0, <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float p, byte n)
		{
			int x = 0;

			if (p <= 0f)
			{
				return x;
			}

			for (; n > 0; --n)
			{
				bool result = iidFunc() <= p;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">Iid source in range [0, 1].</param>
		/// <param name="startPoint"></param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float p, byte n)
		{
			return Generate(iidFunc, p, n) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid source in range [0, 1].</param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range [0, <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float p, byte n) where T : IContinuousGenerator
		{
			int x = 0;

			if (p <= 0f)
			{
				return x;
			}

			for (; n > 0; --n)
			{
				bool result = iidGenerator.Generate() <= p;
				x += *(byte*)&result;
			}

			return x;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">Iid source in range [0, 1].</param>
		/// <param name="startPoint"></param>
		/// <param name="p">True threshold in range [0, 1].</param>
		/// <param name="n"></param>
		/// <returns>Generated value in range
		/// [<paramref name="startPoint"/>, <paramref name="startPoint"/> + <paramref name="n"/>].</returns>
		[Pure]
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float p, byte n)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, p, n) + startPoint;
		}
	}
}
