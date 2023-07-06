// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Xoroshiro128Plus distribution generator using <see cref="Xoroshiro128Plus.NextFloatInclusive()"/>.
	/// </summary>
	public sealed class Xoroshiro128PlusGeneratorInclusive : IXoroshiro128PlusGenerator
	{
		private Xoroshiro128Plus m_randomEngine;

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public Xoroshiro128PlusGeneratorInclusive()
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new Xoroshiro128Plus(tickCount, tickCount);
		}

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public Xoroshiro128PlusGeneratorInclusive(long a, long b)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
		}

		/// <summary>
		/// Creates a <see cref="Xoroshiro128PlusGeneratorInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public Xoroshiro128PlusGeneratorInclusive(ulong a, ulong b)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
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
			get => Xoroshiro128PlusDefaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => Xoroshiro128PlusDefaults.DefaultMax;
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
