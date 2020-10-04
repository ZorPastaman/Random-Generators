// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Provider",
		fileName = "Bates Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = BatesDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BatesDistribution.DefaultDeviation;
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.\nMust be greater than 0.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		[NonSerialized] private BatesGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGenerator(m_Mean, m_Deviation, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BatesGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGenerator batesGenerator
		{
			[Pure]
			get => new BatesGenerator(m_Mean, m_Deviation, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGenerator"/>.
		/// </summary>
		[NotNull]
		public BatesGenerator sharedBatesGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Mean;
			set
			{
				if (m_Mean == value)
				{
					return;
				}

				m_Mean = value;
				m_sharedGenerator = null;
			}
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Deviation;
			set
			{
				if (m_Deviation == value)
				{
					return;
				}

				m_Deviation = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// How many independent and identically distributed random values are generated.
		/// </summary>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Iids;
			set
			{
				if (m_Iids == value)
				{
					return;
				}

				m_Iids = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
