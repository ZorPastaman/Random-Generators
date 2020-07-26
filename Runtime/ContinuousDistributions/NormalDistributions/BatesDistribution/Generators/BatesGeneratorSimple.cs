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
	public sealed class BatesGeneratorSimple : IBatesGenerator
	{
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;

		/// <summary>
		/// Creates a <see cref="BatesGeneratorSimple"/> with the default iids.
		/// </summary>
		public BatesGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="BatesGeneratorSimple"/> with the specified iids.
		/// </summary>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesGeneratorSimple(byte iids)
		{
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGeneratorSimple([NotNull] BatesGeneratorSimple other)
		{
			m_Iids = other.iids;
		}

		public float mean
		{
			[Pure]
			get => BatesDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
			get => BatesDistribution.DefaultDeviation;
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
			return BatesDistribution.Generate(m_Iids);
		}
	}
}
