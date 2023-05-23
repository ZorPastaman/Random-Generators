// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SamePatternFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SamePatterFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_PatternLength = SamePatternFiltering.DefaultPatternLength;
#pragma warning restore CS0649

		private SamePatternFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="SamePatternFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => sameSequenceFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="SamePatternFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter => sharedSameSequenceFilter;

		/// <summary>
		/// Creates a new <see cref="SamePatternFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public SamePatternFilter<T> sameSequenceFilter
		{
			[Pure]
			get => new SamePatternFilter<T>(m_PatternLength);
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

		public byte patternLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_PatternLength;
			set
			{
				if (m_PatternLength == value)
				{
					return;
				}

				m_PatternLength = value;
				m_sharedFilter = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sealed override void DropSharedFilter()
		{
			m_sharedFilter = null;
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
