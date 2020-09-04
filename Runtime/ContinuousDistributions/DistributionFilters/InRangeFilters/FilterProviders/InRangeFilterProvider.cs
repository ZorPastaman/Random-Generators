// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="InRangeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.InRangeContinuousFiltersFolder + "In Range Filter Provider",
		fileName = "In Range Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class InRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private InRangeFilter m_InRangeFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="InRangeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new InRangeFilter(m_InRangeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="InRangeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}

		/// <summary>
		/// Creates a new <see cref="InRangeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public InRangeFilter inRangeFilter
		{
			[Pure]
			get => new InRangeFilter(m_InRangeFilter);
		}

		/// <summary>
		/// Returns a shared see cref="InRangeFilter"/>.
		/// </summary>
		[NotNull]
		public InRangeFilter sharedInRangeFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}
	}
}
