// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
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

		[NonSerialized] private WeightedGeneratorDependent<T, IContinuousGenerator> m_sharedGenerator;

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

		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// How many values are used by its generator.
		/// </summary>
		public int valuesCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Values.Length;
		}

		/// <summary>
		/// Gets a value and weight at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="index"></param>
		/// <returns>Value and weight at the index <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public (T, uint) GetValueWeight(int index)
		{
			return (m_Values[index], m_Weights[index]);
		}

		/// <summary>
		/// Sets a value and weight at the index <paramref name="index"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="weight"></param>
		/// <param name="index"></param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetValueWeight([CanBeNull] T value, uint weight, int index)
		{
			m_Values[index] = value;
			m_Weights[index] = weight;
			m_sharedGenerator = null;
		}

		/// <summary>
		/// Sets values and weights
		/// </summary>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <remarks>
		/// Counts of Values and Weights must be the same.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetValuesWeights([NotNull] T[] values, [NotNull] uint[] weights)
		{
			m_Values = values;
			m_Weights = weights;
			m_sharedGenerator = null;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sealed override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
