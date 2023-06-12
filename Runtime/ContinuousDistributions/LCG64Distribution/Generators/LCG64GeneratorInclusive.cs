// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// LCG64 distribution generator using <see cref="LCG64.NextFloatInclusive()"/>.
	/// </summary>
	public sealed class LCG64GeneratorInclusive : ILCG64Generator
	{
		private LCG64 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="LCG64GeneratorInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public LCG64GeneratorInclusive() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="LCG64GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="seed">Seed.</param>
		public LCG64GeneratorInclusive(int seed)
		{
			m_randomEngine = new LCG64(seed);
		}

		/// <summary>
		/// Creates a <see cref="LCG64GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="LCG64"/>.</param>
		public LCG64GeneratorInclusive(uint initialState)
		{
			m_randomEngine = new LCG64(initialState);
		}

		public LCG64 randomEngine
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_randomEngine;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_randomEngine = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => LCG64Defaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => LCG64Defaults.DefaultMax;
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
