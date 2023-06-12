// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// LCG32 distribution generator using <see cref="LCG32.NextFloatInclusive()"/>.
	/// </summary>
	public sealed class LCG32GeneratorInclusive : ILCG32Generator
	{
		private LCG32 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public LCG32GeneratorInclusive() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="seed">Seed.</param>
		public LCG32GeneratorInclusive(int seed)
		{
			m_randomEngine = new LCG32(seed);
		}

		/// <summary>
		/// Creates a <see cref="LCG32GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="LCG32"/>.</param>
		public LCG32GeneratorInclusive(uint initialState)
		{
			m_randomEngine = new LCG32(initialState);
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
			get => LCG32Defaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => LCG32Defaults.DefaultMax;
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
			return m_randomEngine.NextFloatInclusive();
		}
	}
}
