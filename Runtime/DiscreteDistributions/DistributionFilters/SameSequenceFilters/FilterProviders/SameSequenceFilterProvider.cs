// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="SameSequenceFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SameSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_AllowedSequenceLength = SameSequenceFiltering.DefaultAllowedSequenceLength;
#pragma warning restore CS0649

		private SameSequenceFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="SameSequenceFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new SameSequenceFilter<T>(m_AllowedSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="SameSequenceFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
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
		/// Creates a new <see cref="SameSequenceFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public SameSequenceFilter<T> sameSequenceFilter
		{
			[Pure]
			get => new SameSequenceFilter<T>(m_AllowedSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="SameSequenceFilter{T}"/>.
		/// </summary>
		[NotNull]
		public SameSequenceFilter<T> sharedSameSequenceFilter
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

		public byte allowedSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_AllowedSequenceLength;
			set
			{
				if (m_AllowedSequenceLength == value)
				{
					return;
				}

				m_AllowedSequenceLength = value;
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
