// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(Func{float},byte)"/>.
	/// </summary>
	public sealed class BatesRandomGeneratorFuncDependentSimple : IBatesRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesRandomGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc,
			byte iids = BatesDistribution.DefaultIids)
		{
			m_iidFunc = iidFunc;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGeneratorFuncDependentSimple([NotNull] BatesRandomGeneratorFuncDependentSimple other)
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
			get => m_iidFunc;
			set => m_iidFunc = value;
		}

		public float mean => BatesDistribution.DefaultMean;

		public float deviation => BatesDistribution.DefaultDeviation;

		/// <inheritdoc/>
		public byte iids
		{
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return BatesDistribution.Generate(m_iidFunc, m_iids);
		}
	}
}
