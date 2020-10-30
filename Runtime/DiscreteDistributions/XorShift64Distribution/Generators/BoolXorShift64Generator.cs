// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// XorShift64 distribution generator using <see cref="XorShift64.NextBool()"/>.
	/// </summary>
	public sealed class BoolXorShift64Generator : IXorShift64Generator<bool>
	{
		private XorShift64 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="BoolXorShift64Generator"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public BoolXorShift64Generator() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public BoolXorShift64Generator(long seed)
		{
			m_randomEngine = new XorShift64(seed);
		}

		/// <summary>
		/// Creates a <see cref="BoolXorShift64Generator"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift64"/>. Must be non-zero.</param>
		public BoolXorShift64Generator(ulong initialState)
		{
			m_randomEngine = new XorShift64(initialState);
		}

		public XorShift64 randomEngine
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
		public bool Generate()
		{
			return m_randomEngine.NextBool();
		}
	}
}
