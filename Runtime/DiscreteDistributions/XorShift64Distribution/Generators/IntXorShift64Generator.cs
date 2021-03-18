// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift64 distribution generator using <see cref="XorShift64.NextInt(int,int)"/>.
	/// </summary>
	public sealed class IntXorShift64Generator : IXorShift64Generator<int>
	{
		private XorShift64 m_randomEngine;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates an <see cref="IntXorShift64Generator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift64Generator(int min, int max) : this(Environment.TickCount, min, max)
		{
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift64Generator(long seed, int min, int max)
		{
			m_randomEngine = new XorShift64(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift64"/>. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift64Generator(ulong initialState, int min, int max)
		{
			m_randomEngine = new XorShift64(initialState);
			m_min = min;
			m_max = max;
		}

		public XorShift64 randomEngine
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
