// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(float,float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BatesRandomGenerator : IBatesRandomGenerator
	{
		[SerializeField] private float m_Mean = BatesDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BatesDistribution.DefaultDeviation;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGenerator"/> with the default parameters.
		/// </summary>
		public BatesRandomGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="BatesRandomGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesRandomGenerator(float mean, float deviation, byte iids = BatesDistribution.DefaultIids)
		{
			m_Mean = mean;
			m_Deviation = deviation;
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGenerator([NotNull] BatesRandomGenerator other)
		{
			m_Mean = other.m_Mean;
			m_Deviation = other.m_Deviation;
			m_Iids = other.m_Iids;
		}

		public float mean
		{
			[Pure]
			get => m_Mean;
			set => m_Mean = value;
		}

		public float deviation
		{
			[Pure]
			get => m_Deviation;
			set => m_Deviation = value;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[Pure]
			get => m_Iids;
			set => m_Iids = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_Mean, m_Deviation, m_Iids);
		}
	}
}
