// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator
	/// using <see cref="WeightedDistribution.Generate{T}(T,uint[],WeightedDistribution.Setup)"/>.
	/// </summary>
	/// <typeparam name="TValue">Value type.</typeparam>
	/// <typeparam name="TGenerator"></typeparam>
	public sealed class WeightedGeneratorDependent<TValue, TGenerator> : IWeightedGenerator<TValue>
		where TGenerator : IContinuousGenerator
	{
		[NotNull] private TGenerator m_iidGenerator;
		[NotNull] private TValue[] m_values;
		[NotNull] private uint[] m_weights;
		private WeightedDistribution.Setup m_setup;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorDependent{TValue,TGenerator}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGeneratorDependent([NotNull] TGenerator iidGenerator,
			[NotNull] TValue[] values, [NotNull] uint[] weights)
		{
			m_iidGenerator = iidGenerator;

			int count = Mathf.Min(values.Length, weights.Length);
			m_values = new TValue[count];
			m_weights = new uint[count];

			Array.Copy(values, 0, m_values, 0, count);
			Array.Copy(weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public WeightedGeneratorDependent([NotNull] WeightedGeneratorDependent<TValue, TGenerator> other)
		{
			m_iidGenerator = other.m_iidGenerator;

			int count = other.weightsCount;
			m_values = new TValue[count];
			m_weights = new uint[count];

			Array.Copy(other.m_values, 0, m_values, 0, count);
			Array.Copy(other.m_weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public TGenerator iidGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidGenerator = value;
		}

		public int weightsCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_setup.count;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public uint GetWeight(int index)
		{
			return m_weights[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public TValue GetValue(int index)
		{
			return m_values[index];
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetWeight(uint weight, int index)
		{
			m_weights[index] = weight;
			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetValue(TValue value, int index)
		{
			m_values[index] = value;
		}

		public void SetValueWeights([NotNull] TValue[] values, [NotNull] uint[] weights)
		{
			int count = Mathf.Min(values.Length, weights.Length);
			m_values = new TValue[count];
			m_weights = new uint[count];

			Array.Copy(values, 0, m_values, 0, count);
			Array.Copy(weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public TValue Generate()
		{
			int index = WeightedDistribution.Generate(m_iidGenerator, m_weights, m_setup);
			return m_values[index];
		}
	}
}
