// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Sharp distribution generator using <see cref="Random.NextDouble"/>.
	/// </summary>
	public sealed class SharpGenerator : ISharpGenerator
	{
		[NotNull] private Random m_random;

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

		/// <summary>
		/// Creates a <see cref="SharpGenerator"/> with the specified <see cref="Random"/>.
		/// </summary>
		/// <param name="random"></param>
		public SharpGenerator([NotNull] Random random)
		{
			m_random = random;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public SharpGenerator([NotNull] SharpGenerator other)
		{
			m_random = other.m_random;
		}

		public Random random
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_random;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_random = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => SharpGeneratorDefaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => SharpGeneratorDefaults.DefaultMax;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return (float)m_random.NextDouble();
		}
	}
}
