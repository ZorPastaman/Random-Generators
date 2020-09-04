// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="GreaterFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GreaterContinuousFiltersFolder + "Greater Filter Provider",
		fileName = "Greater Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class GreaterFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private GreaterFilter m_GreaterFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="GreaterFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new GreaterFilter(m_GreaterFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="GreaterFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_GreaterFilter;
		}

		/// <summary>
		/// Creates a new <see cref="GreaterFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public GreaterFilter greaterFilter
		{
			[Pure]
			get => new GreaterFilter(m_GreaterFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="GreaterFilter"/>.
		/// </summary>
		[NotNull]
		public GreaterFilter sharedGreaterFilter
		{
			[Pure]
			get => m_GreaterFilter;
		}
	}
}
