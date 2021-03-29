// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="GammaGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GammaDistributionFolder + "Gamma Generator Provider",
		fileName = "GammaGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class GammaGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue), Tooltip("Shape.")]
		private float m_Alpha = GammaDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = GammaDistribution.DefaultBeta;
#pragma warning restore CS0649

		private GammaGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="GammaGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => gammaGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedGammaGenerator;

		/// <summary>
		/// Creates a new <see cref="GammaGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public GammaGenerator gammaGenerator
		{
			[Pure]
			get => new GammaGenerator(m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGenerator"/>.
		/// </summary>
		[NotNull]
		public GammaGenerator sharedGammaGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = gammaGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Shape.
		/// </summary>
		/// <remarks>
		/// Must be greater than 0.
		/// </remarks>
		public float alpha
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Alpha;
			set
			{
				if (m_Alpha == value)
				{
					return;
				}

				m_Alpha = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// Scale.
		/// </summary>
		public float beta
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Beta;
			set
			{
				if (m_Beta == value)
				{
					return;
				}

				m_Beta = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
