// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGenerator{T}"/>
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class WeightedGeneratorProvider<T> : DiscreteGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private T[] m_Values;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private uint[] m_Weights;
#pragma warning restore CS0649

		private WeightedGenerator<T> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeightedGenerator{T}"/> and returns it
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public sealed override IDiscreteGenerator<T> generator
		{
			[Pure]
			get => new WeightedGenerator<T>(m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared <see cref="WeightedGenerator{T}"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public sealed override IDiscreteGenerator<T> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weightedGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="WeightedGenerator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public WeightedGenerator<T> weightedGenerator
		{
			[Pure]
			get => new WeightedGenerator<T>(m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared <see cref="WeightedGenerator{T}"/>.
		/// </summary>
		[NotNull]
		public WeightedGenerator<T> sharedWeightedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weightedGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
