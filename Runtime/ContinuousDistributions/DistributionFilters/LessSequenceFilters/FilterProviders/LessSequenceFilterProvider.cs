// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LessSequenceFiltersFolder + "Less Sequence Filter Provider",
		fileName = "Less Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LessSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private LessSequenceFilter m_LessSequenceFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new LessSequenceFilter(m_LessSequenceFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_LessSequenceFilter;
		}

		[NotNull]
		public LessSequenceFilter lessSequenceFilter
		{
			[Pure]
			get => new LessSequenceFilter(m_LessSequenceFilter);
		}

		[NotNull]
		public LessSequenceFilter sharedLessSequenceFilter
		{
			[Pure]
			get => m_LessSequenceFilter;
		}
	}
}
