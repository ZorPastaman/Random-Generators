// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceContinuousFiltersFolder + "Extreme Sequence Filter Provider",
		fileName = "Extreme Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class ExtremeSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ExtremeSequenceFilter m_ExtremeSequenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new ExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}

		[NotNull]
		public ExtremeSequenceFilter extremeSequenceFilter
		{
			[Pure]
			get => new ExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		[NotNull]
		public ExtremeSequenceFilter sharedExtremeSequenceFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}
	}
}
