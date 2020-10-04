// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Dependent Simple Provider",
		fileName = "Bates Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorDependentSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.\nMust be greater than 0.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		[NonSerialized] private BatesGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
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
		/// Creates a new <see cref="BatesGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependentSimple<IContinuousGenerator> batesGenerator
		{
			[Pure]
			get => new BatesGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependentSimple<IContinuousGenerator> sharedBatesGenerator
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
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
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
