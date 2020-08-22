// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	public abstract class ContinuousFilterProvider : ScriptableObject
	{
		[NotNull]
		public abstract IContinuousFilter filter { get; }

		[NotNull]
		public abstract IContinuousFilter sharedFilter { get; }
	}
}
