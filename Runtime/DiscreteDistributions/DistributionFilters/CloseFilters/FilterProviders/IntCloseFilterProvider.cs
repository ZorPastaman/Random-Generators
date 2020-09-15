// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="IntCloseFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.CloseDiscreteFiltersFolder + "Int Close Filter Provider",
		fileName = "Int Close Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntCloseFilterProvider : DiscreteFilterProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private IntCloseFilter m_CloseFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="IntCloseFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> filter
		{
			[Pure]
			get => new IntCloseFilter(m_CloseFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="IntCloseFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> sharedFilter
		{
			[Pure]
			get => m_CloseFilter;
		}

		/// <summary>
		/// Creates a new <see cref="IntCloseFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public IntCloseFilter closeFilter
		{
			[Pure]
			get => new IntCloseFilter(m_CloseFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="IntCloseFilter"/>.
		/// </summary>
		[NotNull]
		public IntCloseFilter sharedCloseFilter
		{
			[Pure]
			get => m_CloseFilter;
		}
	}
}
