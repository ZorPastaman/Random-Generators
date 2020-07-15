// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a <see cref="ContinuousRandomGeneratorProvider"/>
	/// and returning a shared or not <see cref="IContinuousRandomGenerator"/> by the specified parameter.
	/// </summary>
	[Serializable]
	public struct ContinuousRandomGeneratorProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProvider m_ContinuousRandomGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IContinuousRandomGenerator"/> by the specified parameter.
		/// </summary>
		/// <returns>Shared or not <see cref="IContinuousRandomGenerator"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		public IContinuousRandomGenerator randomGenerator =>
			m_Shared
				? m_ContinuousRandomGeneratorProvider.sharedRandomGenerator
				: m_ContinuousRandomGeneratorProvider.randomGenerator;
	}
}
