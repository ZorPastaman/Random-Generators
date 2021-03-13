// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Sharp distribution generator using <see cref="Random.Next(int,int)"/>.
	/// </summary>
	public sealed class SharpGenerator : ISharpGenerator<int>
	{
		[NotNull] private Random m_random;
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

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with the specified <see cref="Random"/>.
		/// </summary>
		/// <param name="random"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public SharpGenerator([NotNull] Random random, int min, int max)
		{
			m_random = random;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SharpGenerator([NotNull] SharpGenerator other)
		{
			m_random = other.m_random;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		[NotNull]
		public Random random
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_random;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_random = value;
		}

		public int min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public int max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return m_random.Next(m_min, m_max);
		}
	}
}
