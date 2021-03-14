// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift128 distribution generator using <see cref="XorShift128.NextBool()"/>.
	/// </summary>
	public sealed class BoolXorShift128Generator : IXorShift128Generator<bool>
	{
		private XorShift128 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolXorShift128Generator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolXorShift128Generator()
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new XorShift128(tickCount, tickCount, tickCount, tickCount);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a. Must be non-zero.</param>
		/// <param name="b">Seed b. Must be non-zero.</param>
		/// <param name="c">Seed c. Must be non-zero.</param>
		/// <param name="d">Seed d. Must be non-zero.</param>
		public BoolXorShift128Generator(int a, int b, int c, int d)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Initial state a. Must be non-zero.</param>
		/// <param name="b">Initial state b. Must be non-zero.</param>
		/// <param name="c">Initial state c. Must be non-zero.</param>
		/// <param name="d">Initial state d. Must be non-zero.</param>
		public BoolXorShift128Generator(uint a, uint b, uint c, uint d)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Initial seed. Every item must be non-zero.</param>
		public BoolXorShift128Generator((int, int, int, int) seed)
		{
			m_randomEngine = new XorShift128(seed);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="state">Initial state. Every item must be non-zero.</param>
		public BoolXorShift128Generator((uint, uint, uint, uint) state)
		{
			m_randomEngine = new XorShift128(state);
		}

		public XorShift128 randomEngine
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
		[Pure]
		public bool Generate()
		{
			return m_randomEngine.NextBool();
		}
	}
}
