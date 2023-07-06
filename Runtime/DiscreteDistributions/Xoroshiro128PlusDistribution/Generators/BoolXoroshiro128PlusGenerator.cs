// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Xoroshiro128Plus distribution generator using <see cref="Xoroshiro128Plus.NextBool()"/>.
	/// </summary>
	public sealed class BoolXoroshiro128PlusGenerator : IXoroshiro128PlusGenerator<bool>
	{
		private Xoroshiro128Plus m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolXoroshiro128PlusGenerator"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolXoroshiro128PlusGenerator()
		{
			int tickCount = Environment.TickCount;
			m_randomEngine = new Xoroshiro128Plus(tickCount, tickCount);
		}

		/// <summary>
		/// Creates a <see cref="BoolXoroshiro128PlusGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public BoolXoroshiro128PlusGenerator(long a, long b)
		{
			m_randomEngine = new Xoroshiro128Plus(a, b);
		}

		/// <summary>
		/// Creates a <see cref="BoolXoroshiro128PlusGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialStateA">Initial state a.</param>
		/// <param name="initialStateB">Initial state b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		public BoolXoroshiro128PlusGenerator(ulong initialStateA, ulong initialStateB)
		{
			m_randomEngine = new Xoroshiro128Plus(initialStateA, initialStateB);
		}

		public Xoroshiro128Plus randomEngine
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
