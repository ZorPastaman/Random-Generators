// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GreaterContinuousFiltersFolder + "Greater Sequence Filter Provider",
		fileName = "Greater Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class GreaterFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private GreaterFilter m_GreaterFilter;
#pragma warning restore CS0649

		public override IContinuousFilter filter
		{
			[Pure]
			get => new GreaterFilter(m_GreaterFilter);
		}

		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_GreaterFilter;
		}

		[NotNull]
		public GreaterFilter greaterFilter
		{
			[Pure]
			get => new GreaterFilter(m_GreaterFilter);
		}

		[NotNull]
		public GreaterFilter sharedGreaterFilter
		{
			[Pure]
			get => m_GreaterFilter;
		}
	}
}
