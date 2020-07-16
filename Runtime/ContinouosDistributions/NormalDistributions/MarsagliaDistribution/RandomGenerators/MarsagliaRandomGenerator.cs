// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class MarsagliaRandomGenerator : IMarsagliaRandomGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = MarsagliaDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = MarsagliaDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private float m_spared;
		private bool m_hasSpared;

		/// <summary>
		/// Creates a <see cref="MarsagliaRandomGenerator"/> with the default parameters.
		/// </summary>
		public MarsagliaRandomGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="MarsagliaRandomGenerator"/> with the specified parameters.
		/// </summary>
		public MarsagliaRandomGenerator(float mean, float deviation)
		{
			m_Mean = mean;
			m_Deviation = deviation;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public MarsagliaRandomGenerator([NotNull] MarsagliaRandomGenerator other)
		{
			m_Mean = other.m_Mean;
			m_Deviation = other.m_Deviation;
		}

		public float mean
		{
			get => m_Mean;
			set
			{
				m_Mean = value;
				m_hasSpared = false;
			}
		}

		public float deviation
		{
			get => m_Deviation;
			set
			{
				m_Deviation = value;
				m_hasSpared = false;
			}
		}

		/// <inheritdoc/>
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = MarsagliaDistribution.Generate();
			m_hasSpared = true;

			return answer;
		}
	}
}
