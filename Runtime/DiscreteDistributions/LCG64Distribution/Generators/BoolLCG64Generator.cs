// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// LCG64 distribution generator using <see cref="LCG64.NextBool()"/>.
	/// </summary>
	public sealed class BoolLCG64Generator : ILCG64Generator<bool>
	{
		private LCG64 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolLCG64Generator"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolLCG64Generator() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="BoolLCG64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public BoolLCG64Generator(int seed)
		{
			m_randomEngine = new LCG64(seed);
		}

		/// <summary>
		/// Creates a <see cref="BoolLCG64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="LCG64"/>. Must be non-zero.</param>
		public BoolLCG64Generator(uint initialState)
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
