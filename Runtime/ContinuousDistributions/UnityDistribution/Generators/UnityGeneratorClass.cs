// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.Range(float,float)"/>.
	/// </summary>
	public sealed class UnityGeneratorClass : IUnityGenerator
	{
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates an <see cref="UnityGeneratorClass"/> with the specified parameters.
		/// </summary>
		public UnityGeneratorClass(float min, float max)
		{
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public UnityGeneratorClass(UnityGeneratorClass other)
		{
			m_min = other.m_min;
			m_max = other.m_max;
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
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return Random.Range(m_min, m_max);
		}
	}
}
