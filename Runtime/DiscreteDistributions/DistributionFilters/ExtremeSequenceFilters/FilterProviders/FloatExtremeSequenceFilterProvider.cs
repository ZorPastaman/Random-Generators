// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceDiscreteFiltersFolder + "Float Extreme Sequence Filter Provider",
		fileName = "Float Extreme Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatExtremeSequenceFilterProvider : DiscreteFilterProvider<float>
	{
#pragma warning disable CS0649
		[SerializeField] private FloatExtremeSequenceFilter m_ExtremeSequenceFilter;
#pragma warning restore CS0649

		public override IDiscreteFilter<float> filter
		{
			[Pure]
			get => new FloatExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		public override IDiscreteFilter<float> sharedFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}

		[NotNull]
		public FloatExtremeSequenceFilter extremeSequenceFilter
		{
			[Pure]
			get => new FloatExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		[NotNull]
		public FloatExtremeSequenceFilter sharedExtremeSequenceFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}
	}
}
