// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(float,float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BatesGenerator : IBatesGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = BatesDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BatesDistribution.DefaultDeviation;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="BatesGenerator"/> with the default parameters.
		/// </summary>
		public BatesGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="BatesGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesGenerator(float mean, float deviation, byte iids)
		{
			m_Mean = mean;
			m_Deviation = deviation;
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGenerator([NotNull] BatesGenerator other)
		{
			m_Mean = other.m_Mean;
			m_Deviation = other.m_Deviation;
			m_Iids = other.m_Iids;
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Mean;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Mean = value;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Deviation;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Deviation = value;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Iids;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Iids = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_Mean, m_Deviation, m_Iids);
		}
	}
}
