// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.Range(float,float)"/>.
	/// </summary>
	public struct UnityGeneratorStruct : IUnityGenerator
	{
		/// <summary>
		/// Random Generator using using <see cref="Random.Range(float,float)"/> and returning values in range [0, 1).
		/// </summary>
		public static readonly UnityGeneratorStruct DefaultExclusive =
			new UnityGeneratorStruct(0f, NumberConstants.SubOne);
		/// <summary>
		/// Random Generator using using <see cref="Random.Range(float,float)"/> and returning values in range [0, 1].
		/// </summary>
		public static readonly UnityGeneratorStruct DefaultInclusive = new UnityGeneratorStruct(0f, 1f);

		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates an <see cref="UnityGeneratorStruct"/> with the specified parameters.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public UnityGeneratorStruct(float min, float max)
		{
			m_min = min;
			m_max = max;
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
