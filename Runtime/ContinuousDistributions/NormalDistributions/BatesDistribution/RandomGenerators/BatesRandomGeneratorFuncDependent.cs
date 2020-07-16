// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate(Func{float},float,float,byte)"/>.
	/// </summary>
	public sealed class BatesRandomGeneratorFuncDependent : IBatesRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_mean;
		private float m_deviation;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesRandomGeneratorFuncDependent([NotNull] Func<float> iidFunc,
			float mean, float deviation, byte iids = BatesDistribution.DefaultIids)
		{
			m_iidFunc = iidFunc;
			m_mean = mean;
			m_deviation = deviation;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGeneratorFuncDependent([NotNull] BatesRandomGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
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

		public float mean
		{
			get => m_mean;
			set => m_mean = value;
		}

		public float deviation
		{
			get => m_deviation;
			set => m_deviation = value;
		}

		/// <inheritdoc/>
		public byte iids
		{
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return BatesDistribution.Generate(m_iidFunc, m_mean, m_deviation, m_iids);
		}
	}
}
