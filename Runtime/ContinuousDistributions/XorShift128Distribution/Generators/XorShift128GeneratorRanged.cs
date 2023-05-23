// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// XorShift128 distribution generator using <see cref="XorShift128.NextFloat(float,float)"/>.
	/// </summary>
	public sealed class XorShift128GeneratorRanged : IXorShift128Generator
	{
		private XorShift128 m_randomEngine;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorRanged"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift128GeneratorRanged(float min, float max)
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new XorShift128(tickCount, tickCount, tickCount, tickCount);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorRanged"/> with the specified parameters.
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
		public XorShift128GeneratorRanged(int a, int b, int c, int d, float min, float max)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorRanged"/> with the specified parameters.
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
		public XorShift128GeneratorRanged(uint a, uint b, uint c, uint d, float min, float max)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorRanged"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. At least one item must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift128GeneratorRanged((int, int, int, int) seed, float min, float max)
		{
			m_randomEngine = new XorShift128(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorRanged"/> with the specified parameters.
		/// </summary>
		/// <param name="state">Initial state. At least one item must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift128GeneratorRanged((uint, uint, uint, uint) state, float min, float max)
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
		[Pure]
		public float Generate()
		{
			return m_randomEngine.NextFloat(m_min, m_max);
		}
	}
}
