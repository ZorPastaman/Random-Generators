// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Collection of methods that generate a random value using Negative Binomial distribution algorithms.
	/// </summary>
	/// <remarks>
	/// Algorithm from Luc Devroye (1986) "Non-Uniform Random Variate Generation" Section X.4.7 is used here.
	/// </remarks>
	public static class NegativeBinomialDistribution
	{
		public const int DefaultStartPoint = 0;
		public const float DefaultProbability = 0.5f;
		public const byte DefaultSuccesses = 3;

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(float probability, byte successes)
		{
			float lambda = GammaDistribution.Generate(successes, ComputeBeta(probability));
			return PoissonDistribution.Generate(lambda);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(int startPoint, float probability, byte successes)
		{
			return Generate(probability, successes) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate(Setup setup)
		{
			float lambda = GammaDistribution.Generate(setup.gammaSetup, setup.beta);
			return PoissonDistribution.Generate(lambda);
		}

		/// <summary>
		/// Generates a random value using <see cref="UnityGeneratorStruct.DefaultExclusive"/> as an iid source.
		/// </summary>
		/// <param name="setup"></param>
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
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, float probability, byte successes)
		{
			float lambda = GammaDistribution.Generate(iidFunc, successes, ComputeBeta(probability));
			return PoissonDistribution.Generate(iidFunc, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, int startPoint, float probability, byte successes)
		{
			return Generate(iidFunc, probability, successes) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate([NotNull] Func<float> iidFunc, Setup setup)
		{
			float lambda = GammaDistribution.Generate(iidFunc, setup.gammaSetup, setup.beta);
			return PoissonDistribution.Generate(iidFunc, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidFunc"/> as an iid source.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1).
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
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, float probability, byte successes)
			where T : IContinuousGenerator
		{
			float lambda = GammaDistribution.Generate(iidGenerator, successes, ComputeBeta(probability));
			return PoissonDistribution.Generate(iidGenerator, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="probability">True threshold in range (0, 1].</param>
		/// <param name="successes"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// <paramref name="successes"/> must be greater than 0.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, int startPoint, float probability, byte successes)
			where T : IContinuousGenerator
		{
			return Generate(iidGenerator, probability, successes) + startPoint;
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </param>
		/// <param name="setup"></param>
		/// <returns>Generated value.</returns>
		/// <remarks>
		/// It's a faster variant using a precomputed <paramref name="setup"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int Generate<T>([NotNull] T iidGenerator, Setup setup) where T : IContinuousGenerator
		{
			float lambda = GammaDistribution.Generate(iidGenerator, setup.gammaSetup, setup.beta);
			return PoissonDistribution.Generate(iidGenerator, lambda);
		}

		/// <summary>
		/// Generates a random value using <paramref name="iidGenerator"/> as an iid source.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
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
		/// Computes beta.
		/// </summary>
		/// <param name="probability">Probability. Must be in range (0, 1].</param>
		/// <returns>Computed beta.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static float ComputeBeta(float probability)
		{
			return (1f - probability) / probability;
		}

		/// <summary>
		/// Precomputed setup data. It's used in optimized methods in <see cref="NegativeBinomialDistribution"/>.
		/// </summary>
		/// <remarks>
		/// <para>Never use the default constructor.</para>
		/// <para>If you change probability or successes, recreate <see cref="Setup"/>.</para>
		/// </remarks>
		public readonly struct Setup
		{
			public readonly GammaDistribution.Setup gammaSetup;
			public readonly float beta;

			/// <summary>
			/// Creates <see cref="Setup"/> for optimized methods in <see cref="NegativeBinomialDistribution"/>.
			/// </summary>
			/// <param name="probability">True threshold in range (0, 1].</param>
			/// <param name="successes">Success. Must be greater than 0.</param>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Setup(float probability, byte successes)
			{
				gammaSetup = new GammaDistribution.Setup(successes);
				beta = ComputeBeta(probability);
			}
		}
	}
}
