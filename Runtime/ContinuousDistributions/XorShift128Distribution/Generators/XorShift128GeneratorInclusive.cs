// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// XorShift128 distribution generator using <see cref="XorShift128.NextFloatInclusive()"/>.
	/// </summary>
	public sealed class XorShift128GeneratorInclusive : IXorShift128Generator
	{
		private XorShift128 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public XorShift128GeneratorInclusive()
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new XorShift128(tickCount, tickCount, tickCount, tickCount);
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <param name="c">Seed c.</param>
		/// <param name="d">Seed d.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public XorShift128GeneratorInclusive(int a, int b, int c, int d)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <param name="c">Initial state c.</param>
		/// <param name="d">Initial state d.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public XorShift128GeneratorInclusive(uint a, uint b, uint c, uint d)
		{
			m_randomEngine = new XorShift128(a, b, c, d);
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. At least one item must be non-zero.</param>
		public XorShift128GeneratorInclusive((int, int, int, int) seed)
		{
			m_randomEngine = new XorShift128(seed);
		}

		/// <summary>
		/// Creates a <see cref="XorShift128GeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="state">Initial state. At least one item must be non-zero.</param>
		public XorShift128GeneratorInclusive((uint, uint, uint, uint) state)
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift128Defaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift128Defaults.DefaultMax;
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
			return m_randomEngine.NextFloatInclusive();
		}
	}
}
