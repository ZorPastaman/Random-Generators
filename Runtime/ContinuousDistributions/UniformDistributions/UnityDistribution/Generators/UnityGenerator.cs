// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.Range(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class UnityGenerator : IUnityGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = UnityGeneratorDefaults.DefaultMin;
		[SerializeField] private float m_Max = UnityGeneratorDefaults.DefaultMax;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="UnityGenerator"/> with the default parameters.
		/// </summary>
		public UnityGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="UnityGenerator"/> with the specified parameters.
		/// </summary>
		public UnityGenerator(float min, float max)
		{
			m_Min = min;
			m_Max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public UnityGenerator(UnityGenerator other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return Random.Range(m_Min, m_Max);
		}
	}
}
