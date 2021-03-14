// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="NormalGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NormalDistributionFolder + "Normal Generator Depended Provider",
		fileName = "NormalGeneratorDependedProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NormalGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Mean = NormalDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = NormalDistribution.DefaultDeviation;
#pragma warning restore CS0649

		[NonSerialized] private NormalGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NormalGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new NormalGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = normalGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="NormalGeneratorDependent{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public NormalGeneratorDependent<IContinuousGenerator> normalGenerator
		{
			[Pure]
			get => new NormalGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public NormalGeneratorDependent<IContinuousGenerator> sharedNormalGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = normalGenerator;
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
