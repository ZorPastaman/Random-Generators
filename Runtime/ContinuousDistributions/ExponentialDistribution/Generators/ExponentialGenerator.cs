// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class ExponentialGenerator : IExponentialGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Mustn't be zero.")]
		private float m_Lambda = ExponentialDistribution.DefaultLambda;
		[SerializeField] private float m_StartPoint = ExponentialDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="ExponentialGenerator"/> with the default parameters.
		/// </summary>
		public ExponentialGenerator()
		{
		}

		/// <summary>
		/// Creates an <see cref="ExponentialGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		/// <param name="startPoint"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGenerator(float lambda, float startPoint)
		{
			m_Lambda = lambda;
			m_StartPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGenerator([NotNull] ExponentialGenerator other)
		{
			m_Lambda = other.m_Lambda;
			m_StartPoint = other.m_StartPoint;
		}

		/// <summary>
		/// Lambda. Mustn't be zero.
		/// </summary>
		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Lambda;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Lambda = value;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_StartPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExponentialDistribution.Generate(m_Lambda, m_StartPoint);
		}
	}
}
