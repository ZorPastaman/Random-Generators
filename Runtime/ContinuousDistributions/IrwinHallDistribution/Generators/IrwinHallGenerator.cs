// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(float,byte)"/>.
	/// </summary>
	public sealed class IrwinHallGenerator : IIrwinHallGenerator
	{
		private float m_startPoint;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGenerator(float startPoint, byte iids)
		{
			m_startPoint = startPoint;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGenerator([NotNull] IrwinHallGenerator other)
		{
			m_startPoint = other.m_startPoint;
			m_iids = other.m_iids;
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
			return IrwinHallDistribution.Generate(m_startPoint, m_iids);
		}
	}
}
