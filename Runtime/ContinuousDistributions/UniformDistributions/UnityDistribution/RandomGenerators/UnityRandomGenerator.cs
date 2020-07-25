// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.Range(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class UnityRandomGenerator : IContinuousRandomGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = 0f;
		[SerializeField] private float m_Max = 1f;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="UnityRandomGenerator"/> with the default parameters.
		/// </summary>
		public UnityRandomGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="UnityRandomGenerator"/> with the specified parameters.
		/// </summary>
		public UnityRandomGenerator(float min, float max)
		{
			m_Min = min;
			m_Max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public UnityRandomGenerator(UnityRandomGenerator other)
		{
			m_Min = other.m_Min;
			m_Max = other.m_Max;
		}

		public float min
		{
			[Pure]
			get => m_Min;
			set => m_Min = value;
		}

		public float max
		{
			[Pure]
			get => m_Max;
			set => m_Max = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return Random.Range(m_Min, m_Max);
		}
	}
}
