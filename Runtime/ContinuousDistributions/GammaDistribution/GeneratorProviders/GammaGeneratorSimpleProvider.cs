// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="GammaGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GammaDistributionFolder + "Gamma Generator Simple Provider",
		fileName = "Gamma Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class GammaGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, SimpleRangeFloat(1.19E-07f, float.MaxValue), Tooltip("Shape.")]
		private float m_Alpha = GammaDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = GammaDistribution.DefaultBeta;
#pragma warning restore CS0649

		[NonSerialized] private GammaGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="GammaGeneratorSimple"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new GammaGeneratorSimple(m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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
		/// Creates a new <see cref="GammaGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public GammaGeneratorSimple gammaGenerator
		{
			[Pure]
			get => new GammaGeneratorSimple(m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public GammaGeneratorSimple sharedGammaGenerator
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