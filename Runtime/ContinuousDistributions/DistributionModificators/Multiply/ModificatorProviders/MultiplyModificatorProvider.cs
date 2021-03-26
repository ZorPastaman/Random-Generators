// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="MultiplyModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousModificatorsFolder + "Multiply Modificator Provider",
		fileName = "MultiplyModificatorProvider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class MultiplyModificatorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Multiplier = MultiplyModificatorDefaults.DefaultMultiplier;
#pragma warning restore CS0649

		private MultiplyModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="MultiplyModificator{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new MultiplyModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator, m_Multiplier);
		}

		/// <summary>
		/// Returns a shared <see cref="MultiplyModificator{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = multiplyModificator;
				}

				return m_sharedModificator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="MultiplyModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public MultiplyModificator<IContinuousGenerator> multiplyModificator
		{
			[Pure]
			get => new MultiplyModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator, m_Multiplier);
		}

		/// <summary>
		/// Returns a shared <see cref="MultiplyModificator{T}"/>.
		/// </summary>
		[NotNull]
		public MultiplyModificator<IContinuousGenerator> sharedMultiplyModificator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = multiplyModificator;
				}

				return m_sharedModificator;
			}
		}

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
				m_sharedModificator = null;
			}
		}

		public float multiplier
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Multiplier;
			set
			{
				if (m_Multiplier == value)
				{
					return;
				}

				m_Multiplier = value;
				m_sharedModificator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedModificator = null;
		}

		private void OnValidate()
		{
			m_sharedModificator = null;
		}
	}
}
