// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceContinuousFiltersFolder +
			"Descendant Sequence Filter Provider",
		fileName = "Descendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class DescendantSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private DescendantSequenceFilter m_DescendantSequenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new DescendantSequenceFilter(m_DescendantSequenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_DescendantSequenceFilter;
		}

		[NotNull]
		public DescendantSequenceFilter descendantSequenceFilter
		{
			[Pure]
			get => new DescendantSequenceFilter(m_DescendantSequenceFilter);
		}

		[NotNull]
		public DescendantSequenceFilter sharedDescendantSequenceFilter
		{
			[Pure]
			get => m_DescendantSequenceFilter;
		}
	}
}
