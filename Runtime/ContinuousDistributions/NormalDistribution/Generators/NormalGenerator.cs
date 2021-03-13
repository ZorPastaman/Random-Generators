// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Normal Random Generator using <see cref="NormalDistribution.Generate(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class NormalGenerator : INormalGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = NormalDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = NormalDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="NormalGenerator"/> with the default parameters.
		/// </summary>
		public NormalGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="NormalGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		public NormalGenerator(float mean, float deviation)
		{
			m_Mean = mean;
			m_Deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public NormalGenerator([NotNull] NormalGenerator other)
		{
			m_Mean = other.m_Mean;
			m_Deviation = other.m_Deviation;
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Mean;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_Mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Deviation;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_Deviation = value;
				m_hasSpared = false;
			}
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = NormalDistribution.Generate(m_Mean, m_Deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
