// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(Func{float},byte)"/>.
	/// </summary>
	public sealed class IrwinHallRandomGeneratorFuncDependentSimple : IIrwinHallRandomGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallRandomGeneratorFuncDependentSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallRandomGeneratorFuncDependentSimple([NotNull] Func<float> iidFunc,
			byte iids = IrwinHallDistribution.DefaultIids)
		{
			m_iidFunc = iidFunc;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallRandomGeneratorFuncDependentSimple([NotNull] IrwinHallRandomGeneratorFuncDependentSimple other)
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

		public float startPoint => IrwinHallDistribution.DefaultStartPoint;

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
			return IrwinHallDistribution.Generate(m_iidFunc, m_iids);
		}
	}
}
