// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LittleDifferenceContinuousFiltersFolder + "Little Difference Filter Provider",
		fileName = "Little Difference Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LittleDifferenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private LittleDifferenceFilter m_LittleDifferenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_LittleDifferenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_LittleDifferenceFilter;
		}

		[NotNull]
		public LittleDifferenceFilter littleDifferenceFilter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_LittleDifferenceFilter);
		}

		[NotNull]
		public LittleDifferenceFilter sharedLittleDifferenceFilter
		{
			[Pure]
			get => m_LittleDifferenceFilter;
		}
	}
}
