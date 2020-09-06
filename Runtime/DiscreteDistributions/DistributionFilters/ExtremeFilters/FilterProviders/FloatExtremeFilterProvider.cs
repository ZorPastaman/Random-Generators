// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FloatExtremeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceDiscreteFiltersFolder + "Float Extreme Filter Provider",
		fileName = "Float Extreme Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatExtremeFilterProvider : DiscreteFilterProvider<float>
	{
#pragma warning disable CS0649
		[SerializeField] private FloatExtremeFilter m_ExtremeFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="FloatExtremeFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> filter
		{
			[Pure]
			get => new FloatExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatExtremeFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> sharedFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}

		/// <summary>
		/// Creates a new <see cref="FloatExtremeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public FloatExtremeFilter extremeFilter
		{
			[Pure]
			get => new FloatExtremeFilter(m_ExtremeFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatExtremeFilter"/>.
		/// </summary>
		[NotNull]
		public FloatExtremeFilter sharedExtremeFilter
		{
			[Pure]
			get => m_ExtremeFilter;
		}
	}
}
