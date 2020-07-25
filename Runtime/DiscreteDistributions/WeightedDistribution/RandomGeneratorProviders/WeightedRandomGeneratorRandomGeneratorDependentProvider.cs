// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedRandomGeneratorRandomGeneratorDependent{T, IContinuousRandomGenerator}"/>
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class WeightedRandomGeneratorRandomGeneratorDependentProvider<T> :
		DiscreteRandomGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGeneratorProvider;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private T[] m_Values;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private uint[] m_Weights;
#pragma warning restore CS0649

		private WeightedRandomGeneratorRandomGeneratorDependent<T, IContinuousRandomGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeightedRandomGeneratorRandomGeneratorDependent{T, IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IDiscreteRandomGenerator{T}"/>.
		/// </summary>
		public override IDiscreteRandomGenerator<T> randomGenerator
		{
			[Pure]
			get =>
				new WeightedRandomGeneratorRandomGeneratorDependent<T, IContinuousRandomGenerator>(
					m_DependedRandomGeneratorProvider.randomGenerator, m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="WeightedRandomGeneratorRandomGeneratorDependent{T, IContinuousRandomGenerator}"/>
		/// as <see cref="IDiscreteRandomGenerator{T}"/>.
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
		/// Creates a new <see cref="WeightedRandomGeneratorRandomGeneratorDependent{T, IContinuousRandomGenerator}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public WeightedRandomGeneratorRandomGeneratorDependent<T, IContinuousRandomGenerator> weightedRandomGenerator
		{
			[Pure]
			get =>
				new WeightedRandomGeneratorRandomGeneratorDependent<T, IContinuousRandomGenerator>(
					m_DependedRandomGeneratorProvider.randomGenerator, m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="WeightedRandomGeneratorRandomGeneratorDependent{T, IContinuousRandomGenerator}"/>.
		/// </summary>
		[NotNull]
		public WeightedRandomGeneratorRandomGeneratorDependent<T, IContinuousRandomGenerator>
			sharedWeightedRandomGenerator
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
