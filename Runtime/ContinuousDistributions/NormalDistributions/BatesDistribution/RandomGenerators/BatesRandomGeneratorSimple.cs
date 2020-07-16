// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BatesRandomGeneratorSimple : IBatesRandomGenerator
	{
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorSimple"/> with the default iids.
		/// </summary>
		public BatesRandomGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorSimple"/> with the specified iids.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesRandomGeneratorSimple(byte iids)
		{
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGeneratorSimple([NotNull] BatesRandomGeneratorSimple other)
		{
			m_Iids = other.iids;
		}

		public float mean => BatesDistribution.DefaultMean;

		public float deviation => BatesDistribution.DefaultDeviation;

		/// <inheritdoc/>
		public byte iids
		{
			get => m_Iids;
			set => m_Iids = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return BatesDistribution.Generate(m_Iids);
		}
	}
}
