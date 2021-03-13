// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Gamma Generator using <see cref="GammaDistribution.Generate(float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class GammaGeneratorSimple : IGammaGenerator
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue), Tooltip("Shape.")]
		private float m_Alpha = GammaDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = GammaDistribution.DefaultBeta;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="GammaGeneratorSimple"/> with the default parameters.
		/// </summary>
		public GammaGeneratorSimple()
		{
		}

		/// <summary>
		/// Creates a <see cref="GammaGeneratorSimple"/> with the specified parameters.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		public GammaGeneratorSimple(float alpha, float beta)
		{
			m_Alpha = alpha;
			m_Beta = beta;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GammaGeneratorSimple([NotNull] GammaGeneratorSimple other)
		{
			m_Alpha = other.m_Alpha;
			m_Beta = other.m_Beta;
		}

		/// <inheritdoc/>
		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public float alpha
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Alpha;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Alpha = value;
		}

		/// <inheritdoc/>
		public float beta
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Beta;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Beta = value;
		}

		public float startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => GammaDistribution.DefaultStartPoint;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return GammaDistribution.Generate(m_Alpha, m_Beta);
		}
	}
}
