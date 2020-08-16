// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[Serializable]
	public struct DiscreteFilterProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteFilterProvider_Base m_FilterProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		public IDisceteFilter<T> GetFilter<T>()
		{
			if (m_FilterProvider is DiscreteFilterProvider<T> typedFilterProvider)
			{
				return m_Shared ? typedFilterProvider.sharedFilter : typedFilterProvider.filter;
			}

			return null;
		}
	}
}
