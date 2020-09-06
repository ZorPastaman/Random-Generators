// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SamePatterFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_MaxSamePatternLength;
#pragma warning restore CS0649

		private SamePatternFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="SamePatternFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new SamePatternFilter<T>(m_MaxSamePatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="SamePatternFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = sameSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="SamePatternFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public SamePatternFilter<T> sameSequenceFilter
		{
			[Pure]
			get => new SamePatternFilter<T>(m_MaxSamePatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="SamePatternFilter{T}"/>.
		/// </summary>
		[NotNull]
		public SamePatternFilter<T> sharedSameSequenceFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = sameSequenceFilter;
				}

				return m_sharedFilter;
			}
		}
	}
}
