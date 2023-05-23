// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(Func{float},byte)"/>.
	/// </summary>
	public sealed class IrwinHallGeneratorFuncDependent : IIrwinHallGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGeneratorFuncDependent([NotNull] Func<float> iidFunc, byte iids)
		{
			m_iidFunc = iidFunc;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public IrwinHallGeneratorFuncDependent([NotNull] IrwinHallGeneratorFuncDependent other)
		{
			m_iidFunc = other.m_iidFunc;
			m_iids = other.m_iids;
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

		/// <inheritdoc/>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iids;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return IrwinHallDistribution.Generate(m_iidFunc, m_iids);
		}
	}
}
