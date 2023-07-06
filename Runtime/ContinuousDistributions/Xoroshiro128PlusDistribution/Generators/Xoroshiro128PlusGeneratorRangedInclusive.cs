// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Xoroshiro128Plus distribution generator using <see cref="Xoroshiro128Plus.NextFloatInclusive(float, float)"/>.
	/// </summary>
	public sealed class Xoroshiro128PlusGeneratorRangedInclusive : IXoroshiro128PlusGenerator
	{
		private Xoroshiro128Plus m_randomEngine;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/>
		/// with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public Xoroshiro128PlusGeneratorRangedInclusive(float min, float max)
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new Xoroshiro128Plus(tickCount, tickCount);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public Xoroshiro128PlusGeneratorRangedInclusive(long a, long b, float min, float max)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorRangedInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public Xoroshiro128PlusGeneratorRangedInclusive(ulong a, ulong b, float min, float max)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
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
			return m_randomEngine.NextFloatInclusive(m_min, m_max);
		}
	}
}
