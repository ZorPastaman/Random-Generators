// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(Func{float},byte)"/>.
	/// </summary>
	public sealed class BatesGeneratorFuncDependentSimple : IBatesGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc,
			byte iids = BatesDistribution.DefaultIids)
		{
			m_iidFunc = iidFunc;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGeneratorFuncDependentSimple([NotNull] BatesGeneratorFuncDependentSimple other)
		{
			m_iidFunc = other.m_iidFunc;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public Func<float> iidFunc
		{
			[Pure]
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		public float mean
		{
			[Pure]
			get => BatesDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
			get => BatesDistribution.DefaultDeviation;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[Pure]
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_iidFunc, m_iids);
		}
	}
}
