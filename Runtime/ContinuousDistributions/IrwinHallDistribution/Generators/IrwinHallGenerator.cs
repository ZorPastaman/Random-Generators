// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate(float,byte)"/>.
	/// </summary>
	[Serializable]
	public sealed class IrwinHallGenerator : IIrwinHallGenerator
	{
#pragma warning disable CS0649
		[SerializeField] private float m_StartPoint = IrwinHallDistribution.DefaultStartPoint;
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="IrwinHallGenerator"/> with default parameters.
		/// </summary>
		public IrwinHallGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="IrwinHallGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="iids">How many independent and identically distributed random values are generated.</param>
		public IrwinHallGenerator(float startPoint, byte iids)
		{
			m_StartPoint = startPoint;
			m_Iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallGenerator([NotNull] IrwinHallGenerator other)
		{
			m_StartPoint = other.m_StartPoint;
			m_Iids = other.m_Iids;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_StartPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_StartPoint = value;
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
			return IrwinHallDistribution.Generate(m_StartPoint, m_Iids);
		}
	}
}
