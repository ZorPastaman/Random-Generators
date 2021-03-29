// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FrequentValueFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class FrequentValueFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ControlledSequenceLength =
			FrequentValueFiltering.DefaultControlledSequenceLength;
		[SerializeField] private byte m_AllowedRepeats = FrequentValueFiltering.DefaultAllowedRepeats;
#pragma warning restore CS0649

		private FrequentValueFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="FrequentValueFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => frequentValueFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="FrequentValueFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter => sharedFrequentValueFilter;

		/// <summary>
		/// Creates a new <see cref="FrequentValueFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public FrequentValueFilter<T> frequentValueFilter
		{
			[Pure]
			get => new FrequentValueFilter<T>(m_ControlledSequenceLength, m_AllowedRepeats);
		}

		/// <summary>
		/// Returns a shared <see cref="FrequentValueFilter{T}"/>.
		/// </summary>
		[NotNull]
		public FrequentValueFilter<T> sharedFrequentValueFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = frequentValueFilter;
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

		public byte allowedRepeats
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_AllowedRepeats;
			set
			{
				if (m_AllowedRepeats == value)
				{
					return;
				}

				m_AllowedRepeats = value;
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
