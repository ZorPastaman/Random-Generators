// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="RepeatingPatternFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class RepeatingPatternFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength =
			RepeatingPatternFiltering.DefaultControlledSequenceLength;
		[SerializeField] private byte m_PatternLength = RepeatingPatternFiltering.DefaultPatternLength;
#pragma warning restore CS0649

		private RepeatingPatternFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="RepeatingPatternFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => repeatingPatternFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="RepeatingPatternFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter => sharedRepeatingPatternFilter;

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
				if (m_sharedFilter == null)
				{
					m_sharedFilter = repeatingPatternFilter;
				}

				return m_sharedFilter;
			}
		}

		public byte controlledSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ControlledSequenceLength;
			set
			{
				if (m_ControlledSequenceLength == value)
				{
					return;
				}

				m_ControlledSequenceLength = value;
				m_sharedFilter = null;
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
