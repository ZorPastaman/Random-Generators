// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="RoundModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteModificatorsFolder + "Round Modificator Provider",
		fileName = "RoundModificatorProvider",
		order = CreateAssetMenuConstants.ModificatorOrder
	)]
	public sealed class RoundModificatorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
#pragma warning restore CS0649

		private RoundModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="RoundModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new RoundModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared <see cref="RoundModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
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
			get => new RoundModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared <see cref="RoundModificator{T}"/>.
		/// </summary>
		[NotNull]
		public RoundModificator<IContinuousGenerator> sharedRoundModificator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = roundModificator;
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
