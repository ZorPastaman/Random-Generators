// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceContinuousFiltersFolder +
			"Ascendant Sequence Filter Provider",
		fileName = "Ascendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class AscendantSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private AscendantSequenceFilter m_AscendantSequenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new AscendantSequenceFilter(m_AscendantSequenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_AscendantSequenceFilter;
		}

		[NotNull]
		public AscendantSequenceFilter ascendantSequenceFilter
		{
			[Pure]
			get => new AscendantSequenceFilter(m_AscendantSequenceFilter);
		}

		[NotNull]
		public AscendantSequenceFilter sharedAscendantSequenceFilter
		{
			[Pure]
			get => m_AscendantSequenceFilter;
		}
	}
}
