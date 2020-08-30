// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a <see cref="ContinuousFilterProvider"/>
	/// and returning a shared or not <see cref="IContinuousFilter"/> by the specified parameter.
	/// </summary>
	[Serializable]
	public struct ContinuousFilterProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousFilterProvider m_FilterProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IContinuousFilter"/> by the specified parameter.
		/// </summary>
		/// <returns>Shared or not <see cref="IContinuousFilter"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[NotNull]
		public IContinuousFilter filter
		{
			[Pure]
			get => m_Shared ? m_FilterProvider.sharedFilter : m_FilterProvider.filter;
		}
	}
}
