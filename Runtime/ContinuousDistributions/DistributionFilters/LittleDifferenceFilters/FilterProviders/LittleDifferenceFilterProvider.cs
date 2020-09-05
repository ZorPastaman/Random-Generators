// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="LittleDifferenceFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LittleDifferenceContinuousFiltersFolder + "Little Difference Filter Provider",
		fileName = "Little Difference Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LittleDifferenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private LittleDifferenceFilter m_LittleDifferenceFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="LittleDifferenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_LittleDifferenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="LittleDifferenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_LittleDifferenceFilter;
		}

		/// <summary>
		/// Creates a new <see cref="LittleDifferenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public LittleDifferenceFilter littleDifferenceFilter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_LittleDifferenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="LittleDifferenceFilter"/>.
		/// </summary>
		[NotNull]
		public LittleDifferenceFilter sharedLittleDifferenceFilter
		{
			[Pure]
			get => m_LittleDifferenceFilter;
		}
	}
}
