﻿// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// XorShift64 distribution generator using <see cref="XorShift64.NextFloatInclusive()"/>.
	/// </summary>
	public sealed class XorShift64GeneratorInclusive : IXorShift64Generator
	{
		private XorShift64 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="XorShift64GeneratorInclusive"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public XorShift64GeneratorInclusive() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="XorShift64GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public XorShift64GeneratorInclusive(long seed)
		{
			m_randomEngine = new XorShift64(seed);
		}

		/// <summary>
		/// Creates a <see cref="XorShift64GeneratorInclusive"/> with the specified parameter.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift64"/>. Must be non-zero.</param>
		public XorShift64GeneratorInclusive(ulong initialState)
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift64Defaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift64Defaults.DefaultMax;
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
