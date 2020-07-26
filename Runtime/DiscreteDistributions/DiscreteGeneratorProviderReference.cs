// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a
	/// <see cref="DiscreteGeneratorProvider_Base"/>
	/// and returning a shared or not <see cref="IDiscreteGenerator{T}"/> by the specified parameter.
	/// </summary>
	/// <seealso cref="RequireDiscreteGenerator"/>.
	[Serializable]
	public struct DiscreteGeneratorProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteGeneratorProvider_Base m_DiscreteGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IDiscreteGenerator{T}"/> by the specified parameter.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <returns>Shared or not <see cref="IDiscreteGenerator{T}"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[CanBeNull]
		public IDiscreteGenerator<T> GetGenerator<T>()
		{
			if (m_DiscreteGeneratorProvider is DiscreteGeneratorProvider<T> discreteGeneratorProvider)
			{
				return m_Shared ? discreteGeneratorProvider.sharedGenerator : discreteGeneratorProvider.generator;
			}

			return null;
		}
	}
}
