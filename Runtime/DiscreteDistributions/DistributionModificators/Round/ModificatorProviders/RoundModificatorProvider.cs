// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		fileName = "Round Modificator Provider",
		order = CreateAssetMenuConstants.ModificatorOrder
	)]
	public sealed class RoundModificatorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
#pragma warning restore CS0649

		private RoundModificator<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="RoundModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new RoundModificator<IContinuousGenerator>(m_DependedGenerator.generator);
		}

		/// <summary>
		/// Returns a shared <see cref="RoundModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = roundModificator;
				}

				return m_sharedGenerator;
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
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = roundModificator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
