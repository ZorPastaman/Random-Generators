// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// <see cref="IContinuousRandomGenerator"/> provider.
	/// </summary>
	public abstract class ContinuousRandomGeneratorProvider : ScriptableObject
	{
		/// <summary>
		/// Creates a new <see cref="IContinuousRandomGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IContinuousRandomGenerator randomGenerator { get; }

		/// <summary>
		/// Returns a shared <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		[NotNull]
		public abstract IContinuousRandomGenerator sharedRandomGenerator { get; }
	}
}
