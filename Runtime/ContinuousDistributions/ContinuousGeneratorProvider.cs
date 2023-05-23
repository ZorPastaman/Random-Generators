// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// <see cref="IContinuousGenerator"/> provider.
	/// </summary>
	public abstract class ContinuousGeneratorProvider : ScriptableObject
	{
		/// <summary>
		/// Creates a new <see cref="IContinuousGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IContinuousGenerator generator { get; }

		/// <summary>
		/// Returns a shared <see cref="IContinuousGenerator"/>.
		/// </summary>
		[NotNull]
		public abstract IContinuousGenerator sharedGenerator { get; }

		/// <summary>
		/// Drops a current shared generator so that a new shared generator is created on <see cref="sharedGenerator"/>.
		/// </summary>
		public abstract void DropSharedGenerator();
	}
}
