// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="NotInRangeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NotInRangeContinuousFiltersFolder + "Not In Range Filter Provider",
		fileName = "Not In Range Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class NotInRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private NotInRangeFilter m_InRangeFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="NotInRangeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new NotInRangeFilter(m_InRangeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="NotInRangeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}

		/// <summary>
		/// Creates a new <see cref="NotInRangeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public NotInRangeFilter inRangeFilter
		{
			[Pure]
			get => new NotInRangeFilter(m_InRangeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="NotInRangeFilter"/>.
		/// </summary>
		[NotNull]
		public NotInRangeFilter sharedInRangeFilter
		{
			[Pure]
			get => m_InRangeFilter;
		}
	}
}
