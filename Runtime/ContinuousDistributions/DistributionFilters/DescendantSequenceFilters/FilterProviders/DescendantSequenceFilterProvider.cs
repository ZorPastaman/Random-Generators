// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="DescendantSequenceFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DescendantSequenceContinuousFiltersFolder +
			"Descendant Sequence Filter Provider",
		fileName = "DescendantSequenceFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class DescendantSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed descendant sequence length.")]
		private byte m_DescendantSequenceLength = DescendantSequenceFiltering.DefaultDescendantSequenceLength;
#pragma warning restore CS0649

		private DescendantSequenceFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => descendantSequenceFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter => sharedDescendantSequenceFilter;

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter descendantSequenceFilter
		{
			[Pure]
			get => new DescendantSequenceFilter(m_DescendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter"/>.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter sharedDescendantSequenceFilter
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
		public override void DropSharedFilter()
		{
			m_sharedFilter = null;
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
