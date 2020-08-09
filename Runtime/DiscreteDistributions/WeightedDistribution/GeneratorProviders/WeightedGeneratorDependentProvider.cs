// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public abstract class WeightedGeneratorDependentProvider<T> : DiscreteGeneratorProvider<T>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private T[] m_Values;
		[SerializeField, Tooltip("Counts of Values and Weights must be the same.")]
		private uint[] m_Weights;
#pragma warning restore CS0649

		private WeightedGeneratorDependent<T, IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public sealed override IDiscreteGenerator<T> generator
		{
			[Pure]
			get => new WeightedGeneratorDependent<T, IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// as <see cref="IDiscreteGenerator{T}"/>.
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
		/// Creates a new <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public WeightedGeneratorDependent<T, IContinuousGenerator> weightedGenerator
		{
			[Pure]
			get => new WeightedGeneratorDependent<T, IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Values, m_Weights);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>.
		/// </summary>
		[NotNull]
		public WeightedGeneratorDependent<T, IContinuousGenerator> sharedWeightedGenerator
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
