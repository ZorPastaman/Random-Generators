// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="BoolOppositePatternFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.OppositePatterDiscreteFiltersFolder + "Bool Opposite Pattern Filter",
		fileName = "Bool Opposite Pattern Filter",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class BoolOppositePatternFilterProvider : DiscreteFilterProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private BoolOppositePatternFilter m_OppositePatternFilter;
#pragma warning restore CS0649

		private BoolOppositePatternFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="BoolOppositePatternFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<bool> filter
		{
			[Pure]
			get => new BoolOppositePatternFilter(m_OppositePatternFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolOppositePatternFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<bool> sharedFilter
		{
			[Pure]
			get => m_OppositePatternFilter;
		}

		/// <summary>
		/// Creates a new <see cref="BoolOppositePatternFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public BoolOppositePatternFilter oppositePatternFilter
		{
			[Pure]
			get => new BoolOppositePatternFilter(m_OppositePatternFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="BoolOppositePatternFilter"/>.
		/// </summary>
		[NotNull]
		public BoolOppositePatternFilter sharedOppositePatternFilter
		{
			[Pure]
			get => m_OppositePatternFilter;
		}
	}
}
