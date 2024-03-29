// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Dependent Provider",
		fileName = "BatesGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, SimpleRangeInt(1, 255), Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		private BatesGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => batesGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedBatesGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependent<IContinuousGenerator> batesGenerator
		{
			[Pure]
			get => new BatesGeneratorDependent<IContinuousGenerator>(m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependent<IContinuousGenerator> sharedBatesGenerator
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
