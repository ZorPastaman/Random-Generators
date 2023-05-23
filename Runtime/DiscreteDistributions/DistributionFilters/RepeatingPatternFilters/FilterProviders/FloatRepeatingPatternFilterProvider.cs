// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="RepeatingPatternFilter{Single}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RepeatingPatternDiscreteFiltersFolder +
			"Float Repeating Pattern Filter Provider",
		fileName = "FloatRepeatingPatternFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatRepeatingPatternFilterProvider : RepeatingPatternFilterProvider<float>
	{
	}
}
