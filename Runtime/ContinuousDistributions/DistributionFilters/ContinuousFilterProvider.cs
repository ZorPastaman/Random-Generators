// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="IContinuousFilter"/>.
	/// </summary>
	public abstract class ContinuousFilterProvider : ScriptableObject
	{
		/// <summary>
		/// Creates a new <see cref="IContinuousFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IContinuousFilter filter { get; }

		/// <summary>
		/// Returns a shared <see cref="IContinuousFilter"/>.
		/// </summary>
		[NotNull]
		public abstract IContinuousFilter sharedFilter { get; }

		/// <summary>
		/// Drops a current shared filter so that a new shared filter is created on <see cref="sharedFilter"/>.
		/// </summary>
		public abstract void DropSharedFilter();
	}
}
