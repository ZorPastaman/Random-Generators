// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// LCG32 distribution generator using <see cref="LCG32.NextBool()"/>.
	/// </summary>
	public sealed class BoolLCG32Generator : ILCG32Generator<bool>
	{
		private LCG32 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolLCG32Generator"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolLCG32Generator() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="BoolLCG32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public BoolLCG32Generator(int seed)
		{
			m_randomEngine = new LCG32(seed);
		}

		/// <summary>
		/// Creates a <see cref="BoolLCG32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="LCG32"/>. Must be non-zero.</param>
		public BoolLCG32Generator(uint initialState)
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

		public bool min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => false;
		}

		public bool max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => true;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Forward(int steps)
		{
			m_randomEngine.Forward(steps);
		}

		/// <inheritdoc/>
		[Pure]
		public bool Generate()
		{
			return m_randomEngine.NextBool();
		}
	}
}
