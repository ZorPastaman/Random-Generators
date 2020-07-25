// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class IrwinHallRandomGeneratorSimple : IIrwinHallRandomGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="IrwinHallRandomGeneratorSimple"/> with the default parameters.
		/// </summary>
		public IrwinHallRandomGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates an <see cref="IrwinHallRandomGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallRandomGeneratorSimple(byte iids)
		{
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallRandomGeneratorSimple([NotNull] IrwinHallRandomGeneratorSimple other)
		{
			m_Iids = other.m_Iids;
		}

		public float startPoint
		{
			[Pure]
			get => IrwinHallDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[Pure]
			get => m_Iids;
			set => m_Iids = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return IrwinHallDistribution.Generate(m_Iids);
		}
	}
}
