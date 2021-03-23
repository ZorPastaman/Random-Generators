// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift128 distribution generator using <see cref="XorShift128.NextInt(int,int)"/>.
	/// </summary>
	public sealed class IntXorShift128Generator : IXorShift128Generator<int>
	{
		private XorShift128 m_randomEngine;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates an <see cref="IntXorShift128Generator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift128Generator(int min, int max)
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new XorShift128(tickCount, tickCount, tickCount, tickCount);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <param name="c">Seed c.</param>
		/// <param name="d">Seed d.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one part of the seed must be non-zero.
		/// </remarks>
		public IntXorShift128Generator(int a, int b, int c, int d, int min, int max)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <param name="c">Initial state c.</param>
		/// <param name="d">Initial state d.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one part of the initial state must be non-zero.
		/// </remarks>
		public IntXorShift128Generator(uint a, uint b, uint c, uint d, int min, int max)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Initial seed. At least one item must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift128Generator((int, int, int, int) seed, int min, int max)
		{
			m_randomEngine = new XorShift128(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift128Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="state">Initial state. At least one item must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift128Generator((uint, uint, uint, uint) state, int min, int max)
		{
			m_randomEngine = new XorShift128(state);
			m_min = min;
			m_max = max;
		}

		public XorShift128 randomEngine
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_randomEngine;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_randomEngine = value;
		}

		public int min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public int max
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
		[Pure]
		public int Generate()
		{
			return m_randomEngine.NextInt(m_min, m_max);
		}
	}
}
