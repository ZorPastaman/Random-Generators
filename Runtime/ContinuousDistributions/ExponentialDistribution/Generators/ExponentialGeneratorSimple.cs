// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Exponential Random Generator using <see cref="ExponentialDistribution.Generate(float)"/>.
	/// </summary>
	[Serializable]
	public sealed class ExponentialGeneratorSimple : IExponentialGenerator
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Mustn't be zero.")]
		private float m_Lambda = ExponentialDistribution.DefaultLambda;
#pragma warning restore CS0649

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorSimple"/> with the default parameters.
		/// </summary>
		public ExponentialGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates an <see cref="ExponentialGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="lambda"></param>
		/// <remarks>
		/// <paramref name="lambda"/> mustn't be zero.
		/// </remarks>
		public ExponentialGeneratorSimple(float lambda)
		{
			m_Lambda = lambda;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ExponentialGeneratorSimple([NotNull] ExponentialGeneratorSimple other)
		{
			m_Lambda = other.m_Lambda;
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
			get => ExponentialDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return ExponentialDistribution.Generate(m_Lambda);
		}
	}
}
