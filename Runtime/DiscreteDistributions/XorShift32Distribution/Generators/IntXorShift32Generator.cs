// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift32 distribution generator using <see cref="XorShift32.NextInt(int,int)"/>.
	/// </summary>
	public sealed class IntXorShift32Generator : IXorShift32Generator<int>
	{
		private XorShift32 m_randomEngine;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates an <see cref="IntXorShift32Generator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift32Generator(int min, int max) : this(Environment.TickCount, min, max)
		{
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift32Generator(int seed, int min, int max)
		{
			m_randomEngine = new XorShift32(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXorShift32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift32"/>. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXorShift32Generator(uint initialState, int min, int max)
		{
			m_randomEngine = new XorShift32(initialState);
			m_min = min;
			m_max = max;
		}

		public XorShift32 randomEngine
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
		public int Generate()
		{
			return m_randomEngine.NextInt(m_min, m_max);
		}
	}
}
