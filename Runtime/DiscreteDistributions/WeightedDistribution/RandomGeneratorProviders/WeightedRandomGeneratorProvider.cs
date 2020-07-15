// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGenerator{T}"/>
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class WeightedRandomGeneratorProvider<T> : DiscreteRandomGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private T[] m_Values;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private uint[] m_Weights;
#pragma warning restore CS0649

		private WeightedRandomGenerator<T> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeightedRandomGenerator{T}"/> and returns it
		/// as <see cref="IDiscreteRandomGenerator{T}"/>.
		/// </summary>
		public override IDiscreteRandomGenerator<T> randomGenerator =>
			new WeightedRandomGenerator<T>(m_Values, m_Weights);

		/// <summary>
		/// Returns a shared <see cref="WeightedRandomGenerator{T}"/> as <see cref="IDiscreteRandomGenerator{T}"/>.
		/// </summary>
		public override IDiscreteRandomGenerator<T> sharedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weightedRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="WeightedRandomGenerator{T}"/> and returns it.
		/// </summary>
		public WeightedRandomGenerator<T> weightedRandomGenerator =>
			new WeightedRandomGenerator<T>(m_Values, m_Weights);

		/// <summary>
		/// Returns a shared <see cref="WeightedRandomGenerator{T}"/>.
		/// </summary>
		public WeightedRandomGenerator<T> sharedWeightedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weightedRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
