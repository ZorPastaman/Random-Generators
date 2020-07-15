// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a
	/// <see cref="DiscreteRandomGeneratorProvider_Base"/>
	/// and returning a shared or not <see cref="IDiscreteRandomGenerator{T}"/> by the specified parameter.
	/// </summary>
	/// <seealso cref="Zor.RandomGenerators.PropertyDrawerAttributes.RequireDiscreteRandomGenerator"/>.
	[Serializable]
	public struct DiscreteRandomGeneratorProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private DiscreteRandomGeneratorProvider_Base m_DiscreteRandomGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IDiscreteRandomGenerator{T}"/> by the specified parameter.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <returns>Shared or not <see cref="IDiscreteRandomGenerator{T}"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		public IDiscreteRandomGenerator<T> GetRandomGenerator<T>()
		{
			if (m_DiscreteRandomGeneratorProvider is DiscreteRandomGeneratorProvider<T>
				typedDiscreteRandomGeneratorProvider)
			{
				return m_Shared
					? typedDiscreteRandomGeneratorProvider.sharedRandomGenerator
					: typedDiscreteRandomGeneratorProvider.randomGenerator;
			}

			return null;
		}
	}
}
