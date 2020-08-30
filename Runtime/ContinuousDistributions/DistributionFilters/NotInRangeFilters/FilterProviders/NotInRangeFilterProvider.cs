// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NotInRangeContinuousFiltersFolder + "Not In Range Filter Provider",
		fileName = "Not In Range Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class NotInRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private NotInRangeFilter m_InRangeFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new NotInRangeFilter(m_InRangeFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}

		[NotNull]
		public NotInRangeFilter inRangeFilter
		{
			[Pure]
			get => new NotInRangeFilter(m_InRangeFilter);
		}

		[NotNull]
		public NotInRangeFilter sharedInRangeFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}
	}
}
