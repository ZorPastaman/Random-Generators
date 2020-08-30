// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LessContinuousFiltersFolder + "Less Sequence Filter Provider",
		fileName = "Less Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LessFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private LessFilter m_LessFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new LessFilter(m_LessFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_LessFilter;
		}

		[NotNull]
		public LessFilter lessFilter
		{
			[Pure]
			get => new LessFilter(m_LessFilter);
		}

		[NotNull]
		public LessFilter sharedLessFilter
		{
			[Pure]
			get => m_LessFilter;
		}
	}
}
