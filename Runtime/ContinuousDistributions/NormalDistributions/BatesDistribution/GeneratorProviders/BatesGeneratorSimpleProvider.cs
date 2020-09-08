// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Simple Provider",
		fileName = "Bates Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		private BatesGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGeneratorSimple(m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
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
		/// Creates a new <see cref="BatesGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGeneratorSimple batesGenerator
		{
			[Pure]
			get => new BatesGeneratorSimple(m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BatesGeneratorSimple sharedBatesGenerator
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
		/// How many independent and identically distributed random variables are generated.
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

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
