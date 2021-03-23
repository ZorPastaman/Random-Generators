// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Weighted random generator
	/// using <see cref="WeightedDistribution.Generate(Func{float},uint[],WeightedDistribution.Setup)"/>.
	/// </summary>
	public sealed class WeightedGeneratorFuncDependent<T> : IWeightedGenerator<T>
	{
		[NotNull] private Func<float> m_iidFunc;
		[NotNull] private T[] m_values;
		[NotNull] private uint[] m_weights;
		private WeightedDistribution.Setup m_setup;

		/// <summary>
		/// Creates a new <see cref="WeightedGeneratorFuncDependent{T}"/>
		/// with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="values"></param>
		/// <param name="weights"></param>
		/// <remarks>
		/// Counts of <paramref name="values"/> and <paramref name="weights"/> must be the same
		/// and greater than 0.
		/// </remarks>
		public WeightedGeneratorFuncDependent([NotNull] Func<float> iidFunc,
			[NotNull] T[] values, [NotNull] uint[] weights)
		{
			m_iidFunc = iidFunc;

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
		public WeightedGeneratorFuncDependent([NotNull] WeightedGeneratorFuncDependent<T> other)
		{
			m_iidFunc = other.m_iidFunc;

			int count = other.weightsCount;
			m_values = new T[count];
			m_weights = new uint[count];

			Array.Copy(other.m_values, 0, m_values, 0, count);
			Array.Copy(other.m_weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <summary>
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
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
			m_values = new T[count];
			m_weights = new uint[count];

			Array.Copy(values, 0, m_values, 0, count);
			Array.Copy(weights, 0, m_weights, 0, count);

			m_setup = new WeightedDistribution.Setup(m_weights);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public T Generate()
		{
			int index = WeightedDistribution.Generate(m_iidFunc, m_weights, m_setup);
			return m_values[index];
		}
	}
}
