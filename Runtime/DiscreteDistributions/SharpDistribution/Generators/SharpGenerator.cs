// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Sharp distribution generator using <see cref="Random.Next(int,int)"/>.
	/// </summary>
	public sealed class SharpGenerator : IDiscreteGenerator<int>
	{
		private readonly Random m_random;
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with default seed.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public SharpGenerator(int min, int max)
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
		public SharpGenerator(int seed, int min, int max)
		{
			m_random = new Random(seed);
			m_min = min;
			m_max = max;
		}

		public int min
		{
			[Pure]
			get => m_min;
			set => m_min = value;
		}

		public int max
		{
			[Pure]
			get => m_max;
			set => m_max = value;
		}

		/// <inheritdoc/>
		[Pure]
		public int Generate()
		{
			return m_random.Next(m_min, m_max);
		}
	}
}
