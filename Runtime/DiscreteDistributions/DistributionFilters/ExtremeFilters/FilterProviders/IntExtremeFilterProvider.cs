// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="IntExtremeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceDiscreteFiltersFolder + "Int Extreme Filter Provider",
		fileName = "Int Extreme Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntExtremeFilterProvider : DiscreteFilterProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private IntExtremeFilter m_ExtremeFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IntExtremeFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> filter
		{
			[Pure]
			get => new IntExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="IntExtremeFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> sharedFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}

		/// <summary>
		/// Creates a new <see cref="IntExtremeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public IntExtremeFilter extremeFilter
		{
			[Pure]
			get => new IntExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="IntExtremeFilter"/>.
		/// </summary>
		[NotNull]
		public IntExtremeFilter sharedExtremeFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}
	}
}
