// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="ClampModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousModificatorsFolder + "Clamp Modificator Provider",
		fileName = "ClampModificatorProvider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class ClampModificatorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Min = ClampModificatorDefaults.DefaultMin;
		[SerializeField] private float m_Max = ClampModificatorDefaults.DefaultMax;
#pragma warning restore CS0649

		private ClampModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => clampModificator;
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedClampModificator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public ClampModificator<IContinuousGenerator> clampModificator
		{
			[Pure]
			get => new ClampModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/>.
		/// </summary>
		[NotNull]
		public ClampModificator<IContinuousGenerator> sharedClampModificator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = clampModificator;
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

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedModificator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
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
