// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a
	/// <see cref="DiscreteFilterProvider_Base"/>
	/// and returning a shared or not <see cref="IDiscreteFilter{T}"/> by the specified parameter.
	/// </summary>
	/// <seealso cref="Zor.RandomGenerators.PropertyDrawerAttributes.RequireDiscreteFilter"/>.
	[Serializable]
	public struct DiscreteFilterProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteFilterProvider_Base m_FilterProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IDiscreteFilter{T}"/> by the specified parameter.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <returns>Shared or not <see cref="IDiscreteFilter{T}"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[CanBeNull]
		public IDiscreteFilter<T> GetFilter<T>()
		{
			if (m_FilterProvider is DiscreteFilterProvider<T> typedFilterProvider)
			{
				return m_Shared ? typedFilterProvider.sharedFilter : typedFilterProvider.filter;
			}

			return null;
		}
	}
}
