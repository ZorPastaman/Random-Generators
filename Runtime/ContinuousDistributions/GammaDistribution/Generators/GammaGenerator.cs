// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Gamma Generator using <see cref="GammaDistribution.Generate(float,float,float)"/>.
	/// </summary>
	[Serializable]
	public sealed class GammaGenerator : IGammaGenerator
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue), Tooltip("Shape.")]
		private float m_Alpha = GammaDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = GammaDistribution.DefaultBeta;
		[SerializeField] private float m_StartPoint = GammaDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a <see cref="GammaGenerator"/> with the default parameters.
		/// </summary>
		public GammaGenerator()
		{
		}

		/// <summary>
		/// Creates a <see cref="GammaGenerator"/> with the specified parameters.
		/// </summary>
		/// <param name="alpha">Shape.</param>
		/// <param name="beta">Scale.</param>
		/// <param name="startPoint"></param>
		/// <remarks>
		/// <paramref name="alpha"/> must be greater than 0.
		/// </remarks>
		public GammaGenerator(float alpha, float beta, float startPoint)
		{
			m_Alpha = alpha;
			m_Beta = beta;
			m_StartPoint = startPoint;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public GammaGenerator([NotNull] GammaGenerator other)
		{
			m_Alpha = other.m_Alpha;
			m_Beta = other.m_Beta;
			m_StartPoint = other.m_StartPoint;
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
			get => m_StartPoint;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_StartPoint = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return GammaDistribution.Generate(m_Alpha, m_Beta, m_StartPoint);
		}
	}
}
