// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(byte)"/>.
	/// </summary>
	public sealed class IrwinHallGenerator : IIrwinHallGenerator
	{
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGenerator(byte iids)
		{
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGenerator([NotNull] IrwinHallGenerator other)
		{
			m_iids = other.m_iids;
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
