// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Xoroshiro128Plus distribution generator using <see cref="Xoroshiro128Plus.NextInt(int,int)"/>.
	/// </summary>
	public sealed class IntXoroshiro128PlusGenerator : IXoroshiro128PlusGenerator<int>
	{
		private Xoroshiro128Plus m_randomEngine;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates an <see cref="IntXoroshiro128PlusGenerator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public IntXoroshiro128PlusGenerator(int min, int max)
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new Xoroshiro128Plus(tickCount, tickCount);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXoroshiro128PlusGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public IntXoroshiro128PlusGenerator(long a, long b, int min, int max)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates an <see cref="IntXoroshiro128PlusGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialStateA">Initial state a.</param>
		/// <param name="initialStateB">Initial state b.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public IntXoroshiro128PlusGenerator(ulong initialStateA, ulong initialStateB, int min, int max)
		{
			m_randomEngine = new Xoroshiro128Plus(initialStateA, initialStateB);
			m_min = min;
			m_max = max;
		}

		public Xoroshiro128Plus randomEngine
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
