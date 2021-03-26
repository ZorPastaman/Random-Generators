// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Provider",
		fileName = "BatesGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeInt(1, 255), Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		[NonSerialized] private BatesGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGenerator(m_Iids);
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
			get => new BatesGenerator(m_Iids);
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

		/// <summary>
		/// How many independent and identically distributed random values are generated.
		/// </summary>
		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
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
