// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Discrete filter for a generated sequence.
	/// </summary>
	public interface IDiscreteFilter<in T>
	{
		/// <summary>
		/// Minimal sequence length required by this filter.
		/// </summary>
		byte requiredSequenceLength { get; }

		/// <summary>
		/// Checks if the generated value <paramref name="newValue"/>
		/// for the sequence <paramref name="sequence"/> needs to be regenerated.
		/// </summary>
		/// <param name="sequence">Sequence of generated and already applied values.</param>
		/// <param name="newValue">New generated value.</param>
		/// <param name="sequenceLength">Current sequence length.</param>
		/// <returns>
		/// <para>True if the value <paramref name="newValue"/> needs to be regenerated.</para>
		/// <para>False if the value <paramref name="newValue"/> doesn't need to be regenerated.</para>
		/// </returns>
		bool NeedRegenerate([NotNull] T[] sequence, [NotNull] T newValue, byte sequenceLength);
	}
}
