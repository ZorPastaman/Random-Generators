// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Sharp distribution generator using <see cref="Random.NextDouble"/> with custom range.
	/// </summary>
	public sealed class SharpGeneratorRanged : IContinuousGenerator
	{
		[NotNull] private Random m_random;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with default seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public SharpGeneratorRanged(float min, float max)
		{
			m_random = new Random();
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with the specified seed.
		/// </summary>
		/// <param name="seed">Seed for the <see cref="Random"/>.</param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public SharpGeneratorRanged(int seed, float min, float max)
		{
			m_random = new Random(seed);
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with the specified <see cref="Random"/>.
		/// </summary>
		/// <param name="random"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public SharpGeneratorRanged([NotNull] Random random, float min, float max)
		{
			m_random = random;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SharpGeneratorRanged([NotNull] SharpGeneratorRanged other)
		{
			m_random = other.m_random;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		[NotNull]
		public Random random
		{
			[Pure]
			get => m_random;
			set => m_random = value;
		}

		public float min
		{
			[Pure]
			get => m_min;
			set => m_min = value;
		}

		public float max
		{
			[Pure]
			get => m_max;
			set => m_max = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return (float)m_random.NextDouble() * (m_max - m_min) + m_min;
		}
	}
}