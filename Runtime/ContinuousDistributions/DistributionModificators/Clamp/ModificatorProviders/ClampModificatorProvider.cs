// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="ClampModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousModificatorsFolder + "Clamp Modificator Provider",
		fileName = "Clamp Modificator Provider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class ClampModificatorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
		[SerializeField] private float m_Min;
		[SerializeField] private float m_Max = 1f;
#pragma warning restore CS0649

		private ClampModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new ClampModificator<IContinuousGenerator>(m_DependedGenerator.generator, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = clampModificator;
				}

				return m_sharedModificator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public ClampModificator<IContinuousGenerator> clampModificator
		{
			[Pure]
			get => new ClampModificator<IContinuousGenerator>(m_DependedGenerator.generator, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/>.
		/// </summary>
		[NotNull]
		public ClampModificator<IContinuousGenerator> sharedClampModificator
		{
			[Pure]
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = clampModificator;
				}

				return m_sharedModificator;
			}
		}
	}
}
