// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// XorShift32 distribution generator using <see cref="XorShift32.NextFloat()"/>.
	/// </summary>
	public sealed class XorShift32Generator : IXorShift32Generator
	{
		private XorShift32 m_randomEngine;

		/// <summary>
		/// Creates a <see cref="XorShift32Generator"/> with <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		public XorShift32Generator() : this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Creates a <see cref="XorShift32Generator"/> with the specified parameter.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		public XorShift32Generator(int seed)
		{
			m_randomEngine = new XorShift32(seed);
		}

		/// <summary>
		/// Creates a <see cref="XorShift32Generator"/> with the specified parameter.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift32"/>. Must be non-zero.</param>
		public XorShift32Generator(uint initialState)
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift32Defaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => XorShift32Defaults.DefaultMax;
		}

		/// <inheritdoc/>
		public void Forward(int steps)
		{
			m_randomEngine.Forward(steps);
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return m_randomEngine.NextFloat();
		}
	}
}
