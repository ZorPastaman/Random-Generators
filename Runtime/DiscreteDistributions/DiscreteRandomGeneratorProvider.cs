// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IDiscreteRandomGenerator{T}"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class DiscreteRandomGeneratorProvider<T> : DiscreteRandomGeneratorProvider_Base
	{
		/// <summary>
		/// Creates a new <see cref="IDiscreteRandomGenerator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IDiscreteRandomGenerator<T> randomGenerator { get; }

		/// <summary>
		/// Returns a shared <see cref="IDiscreteRandomGenerator{T}"/>.
		/// </summary>
		[NotNull]
		public abstract IDiscreteRandomGenerator<T> sharedRandomGenerator { get; }
	}
}
