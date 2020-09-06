// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="RepeatingPatternFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class RepeatingPatternFilterProvider<T> : DiscreteFilterProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength = 9;
		[SerializeField] private byte m_PatternLength = 2;
#pragma warning restore CS0649

		private RepeatingPatternFilter<T> m_sharedRepeatingPatternFilter;

		/// <summary>
		/// Creates a new <see cref="RepeatingPatternFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new RepeatingPatternFilter<T>(m_ControlledSequenceLength, m_PatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="RepeatingPatternFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedRepeatingPatternFilter == null)
				{
					m_sharedRepeatingPatternFilter = repeatingPatternFilter;
				}

				return m_sharedRepeatingPatternFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="RepeatingPatternFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public RepeatingPatternFilter<T> repeatingPatternFilter
		{
			[Pure]
			get => new RepeatingPatternFilter<T>(m_ControlledSequenceLength, m_PatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="RepeatingPatternFilter{T}"/>.
		/// </summary>
		[NotNull]
		public RepeatingPatternFilter<T> sharedRepeatingPatternFilter
		{
			get
			{
				if (m_sharedRepeatingPatternFilter == null)
				{
					m_sharedRepeatingPatternFilter = repeatingPatternFilter;
				}

				return m_sharedRepeatingPatternFilter;
			}
		}
	}
}
