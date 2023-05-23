// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IDiscreteGenerator{T}"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class DiscreteGeneratorProvider<T> : DiscreteGeneratorProvider_Base
	{
		/// <summary>
		/// Creates a new <see cref="IDiscreteGenerator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IDiscreteGenerator<T> generator { get; }

		/// <summary>
		/// Returns a shared <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		[NotNull]
		public abstract IDiscreteGenerator<T> sharedGenerator { get; }

		/// <summary>
		/// Drops a current shared generator so that a new shared generator is created on <see cref="sharedGenerator"/>.
		/// </summary>
		public abstract void DropSharedGenerator();
	}
}
