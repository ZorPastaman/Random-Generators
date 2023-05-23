// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.Range(int,int)"/>.
	/// </summary>
	public sealed class UnityGenerator : IUnityGenerator<int>
	{
		private int m_min;
		private int m_max;

		/// <summary>
		/// Creates an <see cref="UnityGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public UnityGenerator(int min, int max)
		{
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public UnityGenerator([NotNull] UnityGenerator other)
		{
			m_min = other.m_min;
			m_max = other.m_max;
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
			return Random.Range(m_min, m_max);
		}
	}
}
