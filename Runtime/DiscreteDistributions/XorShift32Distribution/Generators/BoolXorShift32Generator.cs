// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift32 distribution generator using <see cref="XorShift32.NextBool()"/>.
	/// </summary>
	public sealed class BoolXorShift32Generator : IXorShift32Generator<bool>
	{
		private XorShift32 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolXorShift32Generator"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolXorShift32Generator() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public BoolXorShift32Generator(int seed)
		{
			m_randomEngine = new XorShift32(seed);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift32Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift32"/>. Must be non-zero.</param>
		public BoolXorShift32Generator(uint initialState)
		{
			m_randomEngine = new XorShift32(initialState);
		}

		public XorShift32 randomEngine
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
		public void Forward(int steps)
		{
			m_randomEngine.Forward(steps);
		}

		/// <inheritdoc/>
		public bool Generate()
		{
			return m_randomEngine.NextBool();
		}
	}
}
