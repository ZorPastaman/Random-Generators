// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		fileName = "Descendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class DescendantSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private DescendantSequenceFilter m_DescendantSequenceFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new DescendantSequenceFilter(m_DescendantSequenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_DescendantSequenceFilter;
		}

		/// <summary>
		/// Creates a new <see cref="DescendantSequenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter descendantSequenceFilter
		{
			[Pure]
			get => new DescendantSequenceFilter(m_DescendantSequenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="DescendantSequenceFilter"/>.
		/// </summary>
		[NotNull]
		public DescendantSequenceFilter sharedDescendantSequenceFilter
		{
			[Pure]
			get => m_DescendantSequenceFilter;
		}
	}
}
