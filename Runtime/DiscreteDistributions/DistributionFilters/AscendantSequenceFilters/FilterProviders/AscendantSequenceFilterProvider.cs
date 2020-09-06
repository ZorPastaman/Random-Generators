// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class AscendantSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IComparable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_AscendantSequenceLength;
#pragma warning restore CS0649

		private AscendantSequenceFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new AscendantSequenceFilter<T>(m_AscendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter<T> ascendantSequenceFilter
		{
			[Pure]
			get => new AscendantSequenceFilter<T>(m_AscendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter{T}"/>.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter<T> sharedAscendantSequenceFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
