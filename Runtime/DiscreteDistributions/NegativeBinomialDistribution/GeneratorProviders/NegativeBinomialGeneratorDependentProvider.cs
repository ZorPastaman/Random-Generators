// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="NegativeBinomialGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NegativeBinomialDistributionFolder +
			"Negative Binomial Generator Dependent Provider",
		fileName = "Negative Binomial Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NegativeBinomialGeneratorDependentProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private int m_StartPoint = NegativeBinomialDistribution.DefaultStartPoint;
		[SerializeField, Range(1.19E-07f, 1f)]
		private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField, Range(1, 255)]
		private byte m_Failures = NegativeBinomialDistribution.DefaultFailures;
#pragma warning restore CS0649

		[NonSerialized] private NegativeBinomialGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorDependent{T}"/> and returns it
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new NegativeBinomialGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_StartPoint, m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorDependent{T}"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = negativeBinomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorDependent<IContinuousGenerator> negativeBinomialGenerator
		{
			[Pure]
			get => new NegativeBinomialGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_StartPoint, m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorDependent<IContinuousGenerator> sharedNegativeBinomialGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = negativeBinomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
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

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_StartPoint;
			set
			{
				if (m_StartPoint == value)
				{
					return;
				}

				m_StartPoint = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// True threshold in range (0, 1].
		/// </summary>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Probability;
			set
			{
				if (m_Probability == value)
				{
					return;
				}

				m_Probability = value;
				m_sharedGenerator = null;
			}
		}

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte failures
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Failures;
			set
			{
				if (m_Failures == value)
				{
					return;
				}

				m_Failures = value;
				m_sharedGenerator = null;
			}
		}

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
