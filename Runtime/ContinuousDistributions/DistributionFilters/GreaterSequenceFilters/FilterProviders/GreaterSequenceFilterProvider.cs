// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GreaterSequenceFiltersFolder + "Greater Sequence Filter Provider",
		fileName = "Greater Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class GreaterSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private GreaterSequenceFilter m_GreaterSequenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new GreaterSequenceFilter(m_GreaterSequenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_GreaterSequenceFilter;
		}

		[NotNull]
		public GreaterSequenceFilter greaterSequenceFilter
		{
			[Pure]
			get => new GreaterSequenceFilter(m_GreaterSequenceFilter);
		}

		[NotNull]
		public GreaterSequenceFilter sharedGreaterSequenceFilter
		{
			[Pure]
			get => m_GreaterSequenceFilter;
		}
	}
}
