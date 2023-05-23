// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator using <see cref="WeightedDistribution.Generate(uint[],WeightedDistribution.Setup)"/>.
	/// </summary>
	/// <typeparam name="T">Value type.</typeparam>
	public sealed class WeightedGenerator<T> : IWeightedGenerator<T>
	{
		[NotNull] private T[] m_values;
		[NotNull] private uint[] m_weights;
		private WeightedDistribution.Setup m_setup;

		/// <summary>
		/// Creates a new <see cref="WeightedGenerator{T}"/> with the specified parameters.
		/// </summary>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGenerator([NotNull] T[] values, [NotNull] uint[] weights)
		{
			int count = Mathf.Min(values.Length, weights.Length);
			m_values = new T[count];
			m_weights = new uint[count];

			Array.Copy(values, 0, m_values, 0, count);
			Array.Copy(weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public WeightedGenerator([NotNull] WeightedGenerator<T> other)
		{
			int count = other.weightsCount;
			m_values = new T[count];
			m_weights = new uint[count];

			Array.Copy(other.m_values, 0, m_values, 0, count);
			Array.Copy(other.m_weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
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
		public T GetValue(int index)
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
		public void SetValue(T value, int index)
		{
			m_values[index] = value;
		}

		public void SetValueWeights([NotNull] T[] values, [NotNull] uint[] weights)
		{
			int count = Mathf.Min(values.Length, weights.Length);

			if (m_values.Length != count)
			{
				m_values = new T[count];
			}

			if (m_weights.Length != count)
			{
				m_weights = new uint[count];
			}

			Array.Copy(values, 0, m_values, 0, count);
			Array.Copy(weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public T Generate()
		{
			int index = WeightedDistribution.Generate(m_weights, m_setup);
			return m_values[index];
		}
	}
}
