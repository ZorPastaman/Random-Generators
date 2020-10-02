// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="NegativeBinomialGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NegativeBinomialDistributionFolder +
			"Negative Binomial Generator Dependent Simple Provider",
		fileName = "Negative Binomial Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NegativeBinomialGeneratorDependentSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Range(0f, 1f)] private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_Failures = NegativeBinomialDistribution.DefaultFailures;
#pragma warning restore CS0649

		private NegativeBinomialGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorDependentSimple{T}"/> and returns it
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new NegativeBinomialGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorDependentSimple{T}"/>
		/// as <see cref="IDiscreteGenerator{T}"/>.
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
		/// Creates a new <see cref="NegativeBinomialGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorDependentSimple<IContinuousGenerator> negativeBinomialGenerator
		{
			[Pure]
			get => new NegativeBinomialGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorDependentSimple<IContinuousGenerator> sharedNegativeBinomialGenerator
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
		/// True threshold in range [0, 1].
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
