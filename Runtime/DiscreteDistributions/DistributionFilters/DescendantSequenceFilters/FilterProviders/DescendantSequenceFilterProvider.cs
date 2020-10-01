// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DescendantSequenceFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DescendantSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IComparable<T>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed descendant sequence length.")] private byte m_DescendantSequenceLength =
			DescendantSequenceFiltering.DefaultDescendantSequenceLength;
#pragma warning restore CS0649

		private DescendantSequenceFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new DescendantSequenceFilter<T>(m_DescendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = descendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter<T> descendantSequenceFilter
		{
			[Pure]
			get => new DescendantSequenceFilter<T>(m_DescendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter{T}"/>.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter<T> sharedDescendantSequenceFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = descendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Allowed descendant sequence length.
		/// </summary>
		public byte descendantSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DescendantSequenceLength;
			set
			{
				if (m_DescendantSequenceLength == value)
				{
					return;
				}

				m_DescendantSequenceLength = value;
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
