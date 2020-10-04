// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class IrwinHallGeneratorSimple : IIrwinHallGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorSimple"/> with the default parameters.
		/// </summary>
		public IrwinHallGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates an <see cref="IrwinHallGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGeneratorSimple(byte iids)
		{
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGeneratorSimple([NotNull] IrwinHallGeneratorSimple other)
		{
			m_Iids = other.m_Iids;
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
			get => m_Iids;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Iids = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return IrwinHallDistribution.Generate(m_Iids);
		}
	}
}
