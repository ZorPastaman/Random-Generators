// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// LCG32 distribution generator using <see cref="LCG32.NextFloatInclusive(float, float)"/>.
	/// </summary>
	public sealed class LCG32GeneratorRangedInclusive : ILCG32Generator
	{
		private LCG32 m_randomEngine;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorRangedInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public LCG32GeneratorRangedInclusive(float min, float max) : this(Environment.TickCount, min, max)
		{
		}

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorRangedInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="seed">Seed.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public LCG32GeneratorRangedInclusive(int seed, float min, float max)
		{
			m_randomEngine = new LCG32(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorRangedInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="LCG32"/>.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public LCG32GeneratorRangedInclusive(uint initialState, float min, float max)
		{
			m_randomEngine = new LCG32(initialState);
			m_min = min;
			m_max = max;
		}

		public LCG32 randomEngine
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_randomEngine;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_randomEngine = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Forward(int steps)
		{
			m_randomEngine.Forward(steps);
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return m_randomEngine.NextFloatInclusive(m_min, m_max);
		}
	}
}
