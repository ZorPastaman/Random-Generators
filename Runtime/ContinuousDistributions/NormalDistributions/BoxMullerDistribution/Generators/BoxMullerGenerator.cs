// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class BoxMullerGenerator : IBoxMullerGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = BoxMullerDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BoxMullerDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="BoxMullerGenerator"/> with the default parameters.
		/// </summary>
		public BoxMullerGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="BoxMullerGenerator"/> with the specified parameters.
		/// </summary>
		public BoxMullerGenerator(float mean, float deviation)
		{
			m_Mean = mean;
			m_Deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BoxMullerGenerator([NotNull] BoxMullerGenerator other)
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
			(answer, m_spared) = BoxMullerDistribution.Generate(m_Mean, m_Deviation);
			m_hasSpared = true;

			return answer;
		}
	}
}
