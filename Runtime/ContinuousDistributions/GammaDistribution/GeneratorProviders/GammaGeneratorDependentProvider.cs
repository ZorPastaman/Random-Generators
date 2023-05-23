// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="GammaGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GammaDistributionFolder + "Gamma Generator Dependent Provider",
		fileName = "GammaGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class GammaGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1).")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue), Tooltip("Shape.")]
		private float m_Alpha = GammaDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = GammaDistribution.DefaultBeta;
#pragma warning restore CS0649

		private GammaGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="GammaGeneratorDependent{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => gammaGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGeneratorDependent{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedGammaGenerator;

		/// <summary>
		/// Creates a new <see cref="GammaGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public GammaGeneratorDependent<IContinuousGenerator> gammaGenerator
		{
			[Pure]
			get => new GammaGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="GammaGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public GammaGeneratorDependent<IContinuousGenerator> sharedGammaGenerator
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
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// Shape
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
