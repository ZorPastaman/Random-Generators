// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="IDiscreteFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class DiscreteFilterProvider<T> : DiscreteFilterProvider_Base
	{
		/// <summary>
		/// Creates a new <see cref="IDiscreteFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public abstract IDiscreteFilter<T> filter { get; }

		/// <summary>
		/// Returns a shared <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		[NotNull]
		public abstract IDiscreteFilter<T> sharedFilter { get; }
	}
}
