// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(byte)"/>.
	/// </summary>
	public sealed class IrwinHallGeneratorSimple : IIrwinHallGenerator
	{
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGeneratorSimple(byte iids)
		{
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGeneratorSimple([NotNull] IrwinHallGeneratorSimple other)
		{
			m_iids = other.m_iids;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => IrwinHallDistribution.DefaultStartPoint;
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
			return IrwinHallDistribution.Generate(m_iids);
		}
	}
}
