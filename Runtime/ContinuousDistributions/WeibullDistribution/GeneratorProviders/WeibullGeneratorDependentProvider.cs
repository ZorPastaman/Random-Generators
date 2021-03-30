// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="WeibullGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeibullDistributionFolder + "Weibull Generator Dependent Provider",
		fileName = "WeibullGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class WeibullGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1).")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Tooltip("Shape. Must be non-zero.")]
		private float m_Alpha = WeibullDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = WeibullDistribution.DefaultBeta;
#pragma warning restore CS0649

		private WeibullGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeibullGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => weibullGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="WeibullGeneratorDependent{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedWeibullGenerator;

		/// <summary>
		/// Creates a new <see cref="WeibullGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public WeibullGeneratorDependent<IContinuousGenerator> weibullGenerator
		{
			[Pure]
			get => new WeibullGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="WeibullGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public WeibullGeneratorDependent<IContinuousGenerator> sharedWeibullGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weibullGenerator;
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
		/// Shape. Mustn't be zero.
		/// </summary>
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
