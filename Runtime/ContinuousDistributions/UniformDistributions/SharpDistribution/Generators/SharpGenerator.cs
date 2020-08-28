// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Sharp distribution generator using <see cref="Random.NextDouble"/>.
	/// </summary>
	public sealed class SharpGenerator : IContinuousGenerator
	{
		private readonly Random m_random;

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with default seed.
		/// </summary>
		public SharpGenerator()
		{
			m_random = new Random();
		}

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with the specified seed.
		/// </summary>
		/// <param name="seed">Seed for the <see cref="Random"/>.</param>
		public SharpGenerator(int seed)
		{
			m_random = new Random(seed);
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return (float)m_random.NextDouble();
		}
	}
}
