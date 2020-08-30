// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.InRangeContinuousFiltersFolder + "In Range Filter Provider",
		fileName = "In Range Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class InRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private InRangeFilter m_InRangeFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new InRangeFilter(m_InRangeFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}

		[NotNull]
		public InRangeFilter inRangeFilter
		{
			[Pure]
			get => new InRangeFilter(m_InRangeFilter);
		}

		[NotNull]
		public InRangeFilter sharedInRangeFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}
	}
}
