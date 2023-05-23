// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="NormalGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NormalDistributionFolder + "Normal Generator Depended Simple Provider",
		fileName = "NormalGeneratorDependedSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NormalGeneratorDependentSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
#pragma warning restore CS0649

		private NormalGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="NormalGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => normalGenerator;
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="NormalGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedNormalGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="NormalGeneratorDependentSimple{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public NormalGeneratorDependentSimple<IContinuousGenerator> normalGenerator
		{
			[Pure]
			get => new NormalGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="NormalGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public NormalGeneratorDependentSimple<IContinuousGenerator> sharedNormalGenerator
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
