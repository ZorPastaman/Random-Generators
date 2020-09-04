// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="ExtremeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeContinuousFiltersFolder + "Extreme Filter Provider",
		fileName = "Extreme Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class ExtremeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ExtremeFilter m_ExtremeFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new ExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public ExtremeFilter extremeFilter
		{
			[Pure]
			get => new ExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeFilter"/>.
		/// </summary>
		[NotNull]
		public ExtremeFilter sharedExtremeFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}
	}
}
