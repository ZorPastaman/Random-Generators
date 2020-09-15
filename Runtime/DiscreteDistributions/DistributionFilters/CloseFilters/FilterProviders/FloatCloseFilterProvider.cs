// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FloatCloseFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.CloseDiscreteFiltersFolder + "Float Close Filter Provider",
		fileName = "Float Close Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatCloseFilterProvider : DiscreteFilterProvider<float>
	{
#pragma warning disable CS0649
		[SerializeField] private FloatCloseFilter m_CloseFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="FloatCloseFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> filter
		{
			[Pure]
			get => new FloatCloseFilter(m_CloseFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatCloseFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> sharedFilter
		{
			[Pure]
			get => m_CloseFilter;
		}

		/// <summary>
		/// Creates a new <see cref="FloatCloseFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public FloatCloseFilter closeFilter
		{
			[Pure]
			get => new FloatCloseFilter(m_CloseFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatCloseFilter"/>.
		/// </summary>
		[NotNull]
		public FloatCloseFilter sharedCloseFilter
		{
			[Pure]
			get => m_CloseFilter;
		}
	}
}
