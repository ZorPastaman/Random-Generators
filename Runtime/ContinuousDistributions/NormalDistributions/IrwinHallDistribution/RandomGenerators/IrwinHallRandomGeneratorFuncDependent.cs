// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(Func{float},float,byte)"/>.
	/// </summary>
	public sealed class IrwinHallRandomGeneratorFuncDependent : IIrwinHallRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_startPoint;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallRandomGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallRandomGeneratorFuncDependent([NotNull] Func<float> iidFunc, float startPoint,
			byte iids = IrwinHallDistribution.DefaultIids)
		{
			m_iidFunc = iidFunc;
			m_startPoint = startPoint;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public IrwinHallRandomGeneratorFuncDependent([NotNull] IrwinHallRandomGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_startPoint = other.m_startPoint;
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

		public float startPoint
		{
			get => m_startPoint;
			set => m_startPoint = value;
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
			return IrwinHallDistribution.Generate(m_iidFunc, m_startPoint, m_iids);
		}
	}
}
