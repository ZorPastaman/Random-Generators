// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class BatesGeneratorSimple : IBatesGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BatesDistribution.DefaultMean;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => BatesDistribution.DefaultDeviation;
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
			return BatesDistribution.Generate(m_Iids);
		}
	}
}
