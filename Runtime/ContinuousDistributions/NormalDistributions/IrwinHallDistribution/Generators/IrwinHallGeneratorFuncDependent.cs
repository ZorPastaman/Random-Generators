// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(Func{float},float,byte)"/>.
	/// </summary>
	public sealed class IrwinHallGeneratorFuncDependent : IIrwinHallGenerator
	{
		[NotNull] private Func<float> m_iidFunc;
		private float m_startPoint;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorFuncDependent"/> with the specified parameters.
		/// </summary>
		/// <param name="iidFunc">
		/// Function that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="startPoint"></param>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallGeneratorFuncDependent([NotNull] Func<float> iidFunc, float startPoint, byte iids)
		{
			m_iidFunc = iidFunc;
			m_startPoint = startPoint;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public IrwinHallGeneratorFuncDependent([NotNull] IrwinHallGeneratorFuncDependent other)
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iidFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iidFunc = value;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_startPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_startPoint = value;
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
			return IrwinHallDistribution.Generate(m_iidFunc, m_startPoint, m_iids);
		}
	}
}
