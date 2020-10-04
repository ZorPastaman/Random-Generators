// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="NegativeBinomialGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NegativeBinomialDistributionFolder +
			"Negative Binomial Generator Simple Provider",
		fileName = "Negative Binomial Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NegativeBinomialGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, 1f)] private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_Failures = NegativeBinomialDistribution.DefaultFailures;
#pragma warning restore CS0649

		[NonSerialized] private NegativeBinomialGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorSimple"/> and returns it
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new NegativeBinomialGeneratorSimple(m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorSimple"/> as <see cref="IDiscreteGenerator{T}"/>.
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
		/// Creates a new <see cref="NegativeBinomialGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorSimple negativeBinomialGenerator
		{
			[Pure]
			get => new NegativeBinomialGeneratorSimple(m_Probability, m_Failures);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorSimple sharedNegativeBinomialGenerator
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
