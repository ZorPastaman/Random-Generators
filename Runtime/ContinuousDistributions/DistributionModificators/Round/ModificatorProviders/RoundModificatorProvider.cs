// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="RoundModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousModificatorsFolder + "Round Modificator Provider",
		fileName = "Round Modificator Provider",
		order = CreateAssetMenuConstants.ModificatorOrder
	)]
	public sealed class RoundModificatorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
#pragma warning restore CS0649

		private RoundModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="RoundModificator{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new RoundModificator<IContinuousGenerator>(m_DependedGenerator.generator);
		}

		/// <summary>
		/// Returns a shared <see cref="RoundModificator{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = roundModificator;
				}

				return m_sharedModificator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="RoundModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public RoundModificator<IContinuousGenerator> roundModificator
		{
			[Pure]
			get => new RoundModificator<IContinuousGenerator>(m_DependedGenerator.generator);
		}

		/// <summary>
		/// Returns a shared <see cref="RoundModificator{T}"/>.
		/// </summary>
		[NotNull]
		public RoundModificator<IContinuousGenerator> sharedRoundModificator
		{
			[Pure]
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = roundModificator;
				}

				return m_sharedModificator;
			}
		}
	}
}