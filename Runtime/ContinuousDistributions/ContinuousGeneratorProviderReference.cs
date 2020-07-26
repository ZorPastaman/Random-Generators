// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a <see cref="ContinuousGeneratorProvider"/>
	/// and returning a shared or not <see cref="IContinuousGenerator"/> by the specified parameter.
	/// </summary>
	[Serializable]
	public struct ContinuousGeneratorProviderReference
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProvider m_ContinuousGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		/// <summary>
		/// Returns a shared or not <see cref="IContinuousGenerator"/> by the specified parameter.
		/// </summary>
		/// <returns>Shared or not <see cref="IContinuousGenerator"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		public IContinuousGenerator generator
		{
			[Pure]
			get => m_Shared ? m_ContinuousGeneratorProvider.sharedGenerator : m_ContinuousGeneratorProvider.generator;
		}
	}
}
