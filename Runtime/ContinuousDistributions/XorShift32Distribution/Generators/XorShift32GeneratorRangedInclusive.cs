// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// XorShift32 distribution generator using <see cref="XorShift32.NextFloatInclusive(float,float)"/>.
	/// </summary>
	public sealed class XorShift32GeneratorRangedInclusive : IXorShift32Generator
	{
		private XorShift32 m_randomEngine;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="XorShift32GeneratorRangedInclusive"/> with the specified min and max
		/// and <see cref="Environment.TickCount"/> as seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift32GeneratorRangedInclusive(float min, float max) : this(Environment.TickCount, min, max)
		{
		}

		/// <summary>
		/// Creates a <see cref="XorShift32GeneratorRangedInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="seed">Seed. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift32GeneratorRangedInclusive(int seed, float min, float max)
		{
			m_randomEngine = new XorShift32(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="XorShift32GeneratorRangedInclusive"/> with the specified parameters.
		/// </summary>
		/// <param name="initialState">Initial state of <see cref="XorShift32"/>. Must be non-zero.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public XorShift32GeneratorRangedInclusive(uint initialState, float min, float max)
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
